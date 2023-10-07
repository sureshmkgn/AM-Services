
using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Consul;
using AM.Services.Projects.Services;
using AM.Common;
using AM.Common.Authentication;
using AM.Common.Consul;
using AM.Common.Dispatchers;
using AM.Common.Mongo;
using AM.Common.Mvc;
using AM.Common.RabbitMq;
using AM.Common.Redis;
using AM.Common.RestEase;
using AM.Common.Swagger;
using AM.Services.Projects.Domain.Projects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AM.Services.Projects.Domain.Projects;
using AM.Services.Projects.Messages.Commands.Products;
using AM.Services.Projects.Messages.Events;


namespace AM.Api
{
    public class Startup
    {
        private static readonly string[] Headers = new []{ "X-Operation", "X-Resource", "X-Total-Count" };
        public IContainer Container { get; private set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            services.AddSwaggerDocs();
            services.AddConsul();
            services.AddJwt();
            services.AddRedis();
            services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors => 
                        cors.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                            .WithExposedHeaders(Headers));
            });
            services.RegisterServiceForwarder<IOperationsService>("operations-service");
            services.RegisterServiceForwarder<IProjectsService>("projects-service");
            
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                    .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddMongo();
            builder.AddMongoRepository<Project>("Projects");
            builder.AddDispatchers();
                    
            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            IApplicationLifetime applicationLifetime, IConsulClient client,
            IStartupInitializer startupInitializer)
        {
            if (env.IsDevelopment() || env.EnvironmentName == "local")
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseAllForwardedHeaders();
            app.UseSwaggerDocs();
            app.UseErrorHandler();
            app.UseAuthentication();
            app.UseAccessTokenValidator();
            app.UseServiceId();
            app.UseMvc();
            app.UseRabbitMq()
                .SubscribeCommand<CreateProject>(onError: (c, e) =>
                    new CreateProductRejected(c.Id, e.Message, e.Code));
            var consulServiceId = app.UseConsul();
            applicationLifetime.ApplicationStopped.Register(() => 
            { 
                client.Agent.ServiceDeregister(consulServiceId); 
                Container.Dispose(); 
            });

            startupInitializer.InitializeAsync();
        }
    }
}
