using DataLayer.Models.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Runtime.InteropServices;
using DataLayer.Models.DTOs.Input;
using Golestan.Services;
using Golestan.Services.Interfaces;
using DataLayer.Models.DTOs.Output;
using Golestan.Aspects;
using Golestan.Aspects.Authorize;
using Golestan.Aspects.ExceptionHandling;
using DataLayer.Models.Entities;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
[HandleExceptions]
public class CourseSectionController : ControllerBase, ICrudController<CourseSectionInputDto,CourseSectionOutputDto>
//todo implement authorization of this class
{
    private readonly ICourseSectionService service;

    public CourseSectionController(ICourseSectionService service) => this.service = service;

    [HttpGet]
    [StudentAuthorize]
    public IEnumerable<CourseSectionOutputDto> List(string token, int pageNumber = 1, int pageSize = 100) => service.List(pageNumber, pageSize);

    [HttpGet("{termId:int}")]
    [StudentAuthorize]
    public IEnumerable<CourseSection> List(int termId, string instructorUsername, string courseTitle, int pageNumber, int pageSize, [FromHeader] string token) =>
        service.List(termId, instructorUsername, courseTitle, pageNumber, pageSize);

    [HttpGet("{courseSectionId:int}")]
    [SpecificInstructorAuthorize]
    public List<StudentScoreOutputDto> ListStudentsOfSpecifiedCourseSection(int courseSectionId, int pageNumber, int pageSize, [FromHeader] string token) => 
        service.ListStudentsByCourseSection(courseSectionId, pageNumber, pageSize);
        //todo only instructor of the course section have access and ofcourse admin

    [HttpPost]
    [InstructorAuthorize]
    public CourseSectionOutputDto Create([FromBody] CourseSectionInputDto dto, [FromHeader] string token) => service.Create(dto);

    [HttpGet("{id:int}")]
    [InstructorAuthorize]
    public CourseSectionOutputDto Read(int courseSectionId, [FromHeader] string token) => service.Read(courseSectionId);

    [HttpPut("{id:int}")]
    [SpecificInstructorAuthorize]
    public CourseSectionOutputDto Update(int courseSectionId, [FromBody] CourseSectionInputDto dto, [FromHeader] string token) => service.Update(courseSectionId, dto);

    [HttpDelete]
    [AdminAuthorize]
    public void Delete(int courseSectionId, [FromHeader] string token) => service.Delete(courseSectionId);
}

