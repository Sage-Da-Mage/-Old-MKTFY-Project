using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MKTFY.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKTFY.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            // Create a Serice scope so we can get a services collection
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider; // Services Collection
                try
                {

                    // Get an ApplicationDbContext instance so we can preform the migrations on it
                    var context = services.GetRequiredService<ApplicationDbContext>();


                    // Preform a migration
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    // Output an error log to the configured logging service
                    // By default the logging service would just output to the console
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error has occured while migrating the database");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
