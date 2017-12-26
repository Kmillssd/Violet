﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using DotNetCore2.EF;
using DotNetCore2.Model.Domain;
using DotNetCore2.EF.Seeds.Dev;

namespace DotNetCore2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<CoreContext>();
                    var appEnvironment = services.GetRequiredService<AppEnvironment>();

                    switch (appEnvironment.Seeding)
                    {
                        case "Dev":
                            CoreDevSeeder.Seed(context);
                            break;
                        default:
                            CoreDevSeeder.Seed(context);
                            break;
                    }
                }
                catch (Exception ex)
                {
                   // var logger = services.GetRequiredService<ILogger<Program>>();
                    //logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
    }
}
