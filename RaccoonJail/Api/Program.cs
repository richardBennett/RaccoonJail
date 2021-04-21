using System;
using System.Diagnostics;
using System.IO;
using Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace api
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName))
            .AddJsonFile("appsettings.json", false, true)
            .AddEnvironmentVariables()
            .Build();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); }).UseSerilog();

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            try
            {
                Log.Information("Starting up");
                CreateHostBuilder(args)
                    .UseWindowsService()
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}