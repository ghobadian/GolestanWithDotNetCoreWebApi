using DataLayer.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<TestStartup>();
            });
}

public class TestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<LoliBase>(options =>
            options.UseInMemoryDatabase("TestDb"));

        // Add your other services here
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure your middleware pipeline here
    }
}