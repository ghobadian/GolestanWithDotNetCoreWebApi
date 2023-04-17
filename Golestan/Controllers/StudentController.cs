using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Entities;
using DataLayer.Services;
using Golestan.Aspects;
using Golestan.Aspects.Authorize;
using Golestan.Aspects.ExceptionHandling;
using Golestan.Services;
using Golestan.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
[HandleExceptions]
public class StudentController : ControllerBase
{
    public readonly IStudentService service;

    public StudentController(IStudentService service)
    {
        this.service = service;
    }


    [HttpPost("{courseSectionId:int}")]
    [StudentAuthorize]
    public CourseSectionRegistrationOutputDto SignUpSection(int courseSectionId, [FromHeader] string token) => service.SignUpSection(courseSectionId, token);//todo fix in service


    [HttpGet("{termId:int}")]
    [StudentAuthorize]
    public StudentAverageDto SeeScoresInSpecifiedTerm(int termId, [FromHeader] string token) =>
        service.SeeScoresInSpecifiedTerm(termId, token);

    [HttpGet]
    [StudentAuthorize]
    public SummeryDto SeeSummery([FromHeader] string token) => service.SeeSummery(token);

    [HttpPost]
    public TokenOutputDto Login([FromHeader] string username, [FromHeader] string password) => service.Login(username, password);

    [HttpGet]
    [InstructorAuthorize]
    public IEnumerable<StudentOutputDto> List([FromHeader] string token, int pageNumber = 1, int pageSize = 100) => service.List(pageNumber, pageSize);

    [HttpPost]
    public StudentOutputDto Create([FromBody] StudentInputDto dto, [FromHeader] string? token) => service.Create(dto);

    [HttpGet]
    [InstructorAuthorize]
    public StudentOutputDto Read(int id, [FromHeader] string token) => service.Read(id);

    [HttpPut]
    [SpecificStudentAuthorize]
    public StudentOutputDto Update(int id, [FromBody] StudentInputDto dto, [FromHeader] string token) => service.Update(id, dto);

    [HttpDelete]
    [AdminAuthorize]
    public void Delete(int id, [FromHeader] string token) => service.Delete(id);
}
