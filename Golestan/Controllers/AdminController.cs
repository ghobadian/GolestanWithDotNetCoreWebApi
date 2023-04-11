using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Users;
using Golestan.Aspects.Authorize;
using Golestan.Aspects.ExceptionHandling;
using Golestan.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
[HandleExceptions]
public class AdminController : ControllerBase
{
    public readonly IAdminService service;

    public AdminController(IAdminService service)
    {
        this.service = service;
    }

    [HttpGet]
    [AdminAuthorize]
    public IEnumerable<AdminOutputDto> List([FromHeader] string token/*int page, *//*int number*/) => service.List(/*page, number*/);

    [HttpPost]
    [AdminAuthorize]
    public AdminOutputDto Create(AdminInputDto admin, [FromHeader] string token) => service.Create(admin);

    [HttpGet("{id:int}")]
    [AdminAuthorize]
    public AdminOutputDto Read(int id, [FromHeader] string token) => service.Read(id);

    [HttpPut("{id:int}")]
    [AdminAuthorize, SpecificAdminAuthorize]
    public AdminOutputDto Update(int id, [FromBody] AdminInputDto admin, [FromHeader] string token) => service.Update(id, admin);

    [HttpDelete("{id:int}")]
    [AdminAuthorize, SpecificAdminAuthorize]
    public void Delete(int id, [FromHeader] string token) => service.Delete(id);

    [HttpPost]
    public TokenOutputDto Login([FromHeader] string username, [FromHeader] string password) => service.Login(username, password);

    [HttpPost("{adminId:int}")]
    [AdminAuthorize]
    public void ActivateAdmin(int adminId, string token) => service.ActivateAdmin(adminId);

    [HttpPost("{instructorId:int}")]
    [AdminAuthorize]
    public void ActivateInstructor(int instructorId, string token) => service.ActivateInstructor(instructorId);

    [HttpPost("{studentId:int}")]
    [AdminAuthorize]
    public void ActivateStudent(int studentId, string token) => service.ActivateStudent(studentId);
}

