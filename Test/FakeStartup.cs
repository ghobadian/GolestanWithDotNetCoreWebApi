//using DataLayer.Contexts;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;

//namespace Test;

//public class FakeStartup : Startup
//{
//    public FakeStartup(IConfiguration configuration) : base(configuration)
//    {
//    }

//    public override void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
//    {
//        base.Configure(app, env, loggerFactory);

//        var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
//        using (var serviceScope = serviceScopeFactory.CreateScope())
//        {
            


//            // Initialize database
//        }
//    }
//}