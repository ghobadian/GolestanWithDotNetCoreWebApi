using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Users;
using Golestan.Aspects;
using Golestan.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
public class AdminController : ControllerBase
{
    public readonly IAdminService service;

    public AdminController(IAdminService service)
    {
        this.service = service;
    }

    [HttpGet]
    [AdminAuthorize]
    public IEnumerable<Admin> List(/*auth*//*int page, *//*int number*/) => service.List(/*page, number*/);

    [HttpPost]
    [AdminAuthorize]
    public Admin Create(AdminInputDto admin, [FromHeader] string token) => service.Create(admin);

    [HttpGet("{id:int}")]
    [AdminAuthorize]
    public Admin Read(int id, [FromHeader] string token) => service.Read(id);

    [HttpPut("{id:int}")]
    [AdminAuthorize, SpecificAdminAuthorize]
    public Admin Update(int id, [FromBody] AdminInputDto admin, [FromHeader] string token) => service.Update(id, admin);

    [HttpDelete("{id:int}")]
    [AdminAuthorize, SpecificAdminAuthorize]
    public void Delete(int id, [FromHeader] string token) => service.Delete(id);

    [HttpPost]
    public TokenOutputDto Login([FromHeader] string username, [FromHeader] string password) => service.Login(username, password);
}

