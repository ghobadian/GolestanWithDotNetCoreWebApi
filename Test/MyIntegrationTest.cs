using DataLayer.Contexts;
using DataLayer.Models.Entities.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Json;
using DataLayer.Models.DTOs.Input;
using Newtonsoft.Json;

public class MyIntegrationTest : IDisposable
{
    private readonly TestServer _server;
    private readonly HttpClient _client;

    public MyIntegrationTest()
    {
        var builder = new WebHostBuilder()
            .UseEnvironment("Development")
            //.UseConfiguration(new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.Test.json")
            //    .Build())
            .UseStartup<TestStartup>();

        _server = new TestServer(builder);
        _client = _server.CreateClient();
    }

    [Fact]
    public async Task test()
    {
        var scope = _server.Services.GetService<IServiceScopeFactory>()!.CreateScope();
        var db = scope.ServiceProvider.GetService<LoliBase>();
        //await _client.PostAsync();

        var response = await _client.PostAsJsonAsync("/Admin/Create", new AdminInputDto("Admin1Admin", "Admin1Admin", "Admin1Admin", "09309485843","7434959851"));

        db.Admins.ToList();

        var async = await _client.GetAsync("Admin/List");
        var readAsStringAsync = await async.Content.ReadAsStringAsync();
    }

    public void Dispose()
    {
        _client.Dispose();
        _server.Dispose();
    }

    // Add your integration test methods here
}