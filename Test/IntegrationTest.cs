using DataLayer.Contexts;
using DataLayer.Enums;
using DataLayer.Models.DTOs;
using DataLayer.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Test
{
    public class IntegrationTest : IClassFixture<WebApplicationFactory<Golestan.Program>>
    {

        private HttpClient _httpClient;
        private LoliBase _db;
        private WebApplicationFactory<Golestan.Program> _factory;
        public IntegrationTest(WebApplicationFactory<Golestan.Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                             typeof(DbContextOptions<LoliBase>));

                    services.Remove(descriptor);

                    services.AddDbContext<LoliBase>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDB");
                    });
                });
            });


            _httpClient = factory.CreateClient();
        }

        [Fact]
        public void test()
        {
            //var scope = _factory.Services.GetService<IServiceScopeFactory>()!.CreateScope();
            //var db = scope.ServiceProvider.GetService<LoliBase>();

            //var dbContextOptionsBuilder = new DbContextOptionsBuilder<LoliBase>().UseInMemoryDatabase("test");
            //Golestan.Program.builder.Services.AddDbContext<LoliBase>(options => options.UseInMemoryDatabase("test"));

            //_db = new LoliBase(dbContextOptionsBuilder.Options);
            //var dbContextOptionsBuilder = new DbContextOptionsBuilder<LoliBase>().UseInMemoryDatabase("test");
            //LoliBase db = new LoliBase(dbContextOptionsBuilder.Options);
            //_httpClient.DefaultRequestHeaders.Add("token", "token");
            //var response = await _httpClient.GetAsync("/admin/List");
            //var result = await response.Content.ReadAsStringAsync();
            //Loader.LoadData(db, _httpClient);
        }
    }
}