using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Entities;
using DataLayer.Models.Entities.Users;
using Golestan.Aspects.Authorize;
using Golestan.Aspects.ExceptionHandling;
using Golestan.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
[HandleExceptions]
public class CourseController : ControllerBase , ICrudController<CourseInputDto, CourseOutputDto>
{

    public readonly ICourseService service;
    public CourseController(ICourseService service) => this.service = service;

    [HttpGet]
    public IEnumerable<CourseOutputDto> List([FromHeader] string token, int pageNumber = 1, int pageSize = 100) => service.List(pageNumber, pageSize);

    [HttpPost]
    [InstructorAuthorize]
    public CourseOutputDto Create([FromBody] CourseInputDto dto, [FromHeader] string token) => service.Create(dto);

    [HttpGet("{id:int}")]
    [StudentAuthorize]
    public CourseOutputDto Read(int courseId, [FromHeader] string token) => service.Read(courseId);

    [HttpPut("{id:int}")]
    [SpecificInstructorAuthorize]
    public CourseOutputDto Update(int courseId, [FromBody] CourseInputDto dto, [FromHeader] string token) => service.Update(courseId, dto);


    [HttpDelete("{id:int}")]
    [AdminAuthorize]
    public void Delete(int courseId, [FromHeader] string token) => service.Delete(courseId);
}

