//using DataLayer.Contexts;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//namespace Test;

//public class TestStartup : Golestan.Startup
//{
//    public TestStartup(IConfiguration configuration) : base(configuration)
//    {
//    }

//    public override void ConfigureDevelopmentServices(IServiceCollection services)
//    {
//        // Use an in-memory database for testing
//        services.AddDbContext<LoliBase>(options =>
//            options.UseInMemoryDatabase("TestDb"));
//    }
//}