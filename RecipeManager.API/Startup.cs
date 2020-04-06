using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<UnitOfWork>();
            services.AddEntityFrameworkNpgsql().AddDbContext<RecipeContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("PostgresConnectionString")));
            services.AddAutoMapper(typeof(RecipeProfile));

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
