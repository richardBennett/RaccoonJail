using Database.Models;
using Database.Services;
using Database.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Raccoon Jail Api");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RaccoonJailContext>(
                options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]),
                ServiceLifetime.Transient);

            services.AddSwaggerGen();

            services.AddScoped<IInmateCrudService, InmateCrudService>();

            services.AddControllers();
        }
    }
}