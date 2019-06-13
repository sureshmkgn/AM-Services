using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using FA.Common.Logging;
using FA.Common.Metrics;
using FA.Common.Mvc;
using FA.Common.Vault;
using System;

namespace FA.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseLogging()
                .UseVault()
                .UseLockbox()
                .UseAppMetrics();
    }
}
