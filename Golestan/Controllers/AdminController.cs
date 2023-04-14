using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using Golestan.Aspects.Authorize;
using Golestan.Aspects.ExceptionHandling;
using Golestan.Aspects.UserActivation;
using Golestan.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
[HandleExceptions]
public class AdminController : ControllerBase, ICrudController<AdminInputDto, AdminOutputDto>
{
    public readonly IAdminService service;

    public AdminController(IAdminService service)
    {
        this.service = service;
    }

    [HttpGet]
    [AdminAuthorize]//todo sorting filtering and pagination
    public IEnumerable<AdminOutputDto> List([FromHeader] string token, int pageNumber = 1, int pageSize = 100) => service.List(pageNumber, pageSize);

    [HttpPost]
    public AdminOutputDto Create([FromBody] AdminInputDto dto, [FromHeader] string? token) => service.Create(dto);

    [HttpGet("{id:int}")]
    [AdminAuthorize]
    public AdminOutputDto Read(int id, [FromHeader] string token) => service.Read(id);

    [HttpPut("{id:int}")]
    [SpecificAdminAuthorize]
    public AdminOutputDto Update(int id, [FromBody] AdminInputDto admin, [FromHeader] string token) => service.Update(id, admin);

    [HttpDelete("{id:int}")]
    [SpecificAdminAuthorize]
    public void Delete(int id, [FromHeader] string token) => service.Delete(id);

    [HttpPost]
    public TokenOutputDto Login([FromHeader] string username, [FromHeader] string password) => service.Login(username, password);

    [HttpPost("{adminId:int}")]
    [AdminAuthorize]
    [AdminActivation]
    public void ActivateAdmin(int adminId, [FromHeader] string token) => service.ActivateAdmin(adminId);

    [HttpPost("{instructorId:int}")]
    [AdminAuthorize]
    [InstructorActivation]
    public void ActivateInstructor(int instructorId, [FromHeader] string token) => service.ActivateInstructor(instructorId);

    [HttpPost("{studentId:int}")]
    [AdminAuthorize]
    [StudentAuthorize]
    public void ActivateStudent(int studentId, [FromHeader] string token) => service.ActivateStudent(studentId);
}

