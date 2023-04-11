
using DataLayer.Models;
using DataLayer.Models.Users;
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

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
[HandleExceptions]
public class CourseSectionController
{
    private readonly ICourseSectionService service;

    public CourseSectionController(ICourseSectionService service) => this.service = service;

    [HttpGet("{termId:int}")]
    [StudentAuthorize]
    public IEnumerable<CourseSection> List(int termId, /*auth*/string instructorUsername, string courseTitle /*Integer pageNumber,*/ /*Integer maxInEachPage*/) =>
        service.List(termId, instructorUsername, courseTitle/*, pageNumber, maxInEachPage*/);

    [HttpGet("{courseSectionId:int}")]
    [AdminAuthorize]
    [InstructorAuthorize]
    [SpecificInstructorAuthorize]
    public List<StudentScoreOutputDto> ListStudentsOfSpecifiedCourseSection( int courseSectionId /*auth*/) => 
        service.ListStudentsByCourseSection(courseSectionId);
        //todo only instructor of the course section have access and ofcourse admin

    [HttpPost]
    public CourseSectionOutputDto Create(CourseSectionInputDto dto /*auth*/) => service.Create(dto);

    [HttpGet("{id:int}")]
    public CourseSectionOutputDto Read(int id/*auth*/)
    => service.Read(id);

    [HttpPut("{id:int}")]
    public CourseSectionOutputDto Update(int id, CourseSectionInputDto dto /*auth*/) => service.Update(id, dto);

    [HttpDelete]
    public void Delete(int id /*auth*/) => service.Delete(id);
}

