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
using MKTFY.Api.Swashbuckle;
using MKTFY.Repositories;
using MKTFY.Repositories.Repositories;
using MKTFY.Repositories.Repositories.Interfaces;
using MKTFY.Services.Services;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MKTFY.Api
{
    /// <summary>
    /// The startup file
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The constructor that takes in an IConfiguration as input
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Get the Iconfiguration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Adding depenency injection to the startup file
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureDependencyInjection(IServiceCollection services)
        {
            // Configure the dependency injection
            services.AddScoped<IListingService, ListingService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IListingRepository, ListingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            // Add Swagger generator to create JSON documentation content
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "MKTFY API", Version = "v2" });

                var apiPath = Path.Combine(System.AppContext.BaseDirectory, "MKTFY.API.xml");
                var modelsPath = Path.Combine(System.AppContext.BaseDirectory, "MKTFY.Models.xml");
                c.IncludeXmlComments(apiPath);
                c.IncludeXmlComments(modelsPath);

                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
                c.OperationFilter<AuthHeaderOperationFilter>();

            });


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

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            // Make Swagger JSON file available
            app.UseSwagger();

            // Make Swagger UI available at /swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "MKTFY API V2");
            });


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
