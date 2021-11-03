using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MKTFY.Api.Middleware;
using MKTFY.Repositories;
using MKTFY.Repositories.Repositories;
using MKTFY.Repositories.Repositories.Interfaces;
using MKTFY.Services.Services;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKTFY.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Adding depenency injection to the startup file
        public void ConfigureDependencyInjection(IServiceCollection services)
        {
            // Configure the dependency injection
            services.AddScoped<IListingService, ListingService>();
            services.AddScoped<IListingRepository, ListingRepository>();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //{
            // Setup our database using the ApplicationDbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql( // Connect to the postgres database
                    Configuration.GetConnectionString("DefaultConnection"),
                    builder => 
                    {
                        // Configure what project we want to store our Code-First Migrations in
                        builder.MigrationsAssembly("MKTFY.Repositories");
                    })
                );
                //}



            services.AddControllers();

            // Setup authentication
            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration.GetSection("Auth0").GetValue<string>("Domain");
                    options.Audience = Configuration.GetSection("Auth0").GetValue<string>("Audience");
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        RoleClaimType = "http://schemas.mktfy.com/roles"
                    };
                });

            // Call the method for configuring dependency injection
            ConfigureDependencyInjection(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MKTFY.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MKTFY.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Implement the global error handler
            app.UseMiddleware<GlobalExceptionHandler>();

            // Implement authentication 
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
