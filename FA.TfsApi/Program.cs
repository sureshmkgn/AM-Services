using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using AM.Common.Logging;
using AM.Common.Metrics;
using AM.Common.Mvc;
using AM.Common.Vault;
using System;

namespace AM.Api
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
