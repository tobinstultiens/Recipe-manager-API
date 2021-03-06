using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RecipeManager.API.Application.Interfaces;
using RecipeManager.API.Application.Services;
using RecipeManager.API.Infrastructure.AutomapperConfigurations;
using RecipeManager.API.Persistence.EntityFramework;
using RecipeManager.API.Persistence.EntityFramework.Contexts;

namespace RecipeManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var test = Configuration.GetConnectionString("PostgresConnectionString");
            services.AddDbContext<RecipeContext>(opt =>
            {
                opt.UseNpgsql(Configuration.GetConnectionString("PostgresConnectionString"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddAutoMapper(typeof(RecipeProfile));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://securetoken.google.com/recipe-manager-e0544";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/recipe-manager-e0544",
                        ValidateAudience = true,
                        ValidAudience = "recipe-manager-e0544",
                        ValidateLifetime = true
                    };
                });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
