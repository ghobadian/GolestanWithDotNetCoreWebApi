
using DataLayer.Models;
using DataLayer.Models.Users;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Runtime.InteropServices;
using DataLayer.Models.DTOs.Input;
using Golestan.Services;
using Golestan.Services.Interfaces;
using DataLayer.Models.DTOs.Output;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
public class CourseSectionController
{
    private readonly ICourseSectionService service;

    public CourseSectionController(ICourseSectionService service) => this.service = service;

    [HttpGet("{termId:int}")]
    public IEnumerable<CourseSection> List(int termId, /*auth*/string instructorName, string courseName /*Integer pageNumber,*/ /*Integer maxInEachPage*/) =>
        service.List(termId, instructorName, courseName/*, pageNumber, maxInEachPage*/);

    [HttpGet("{courseSectionId:int}")]
    public List<StudentDto> ListStudentsOfSpecifiedCourseSection( int courseSectionId /*auth*/) => 
        service.ListStudentsByCourseSection(courseSectionId);
        //todo only instructor of the course section have access and ofcourse admin

    [HttpPost]
    public CourseSection Create(CourseSectionInputDto dto /*auth*/) => service.Create(dto);

    [HttpGet("{id:int}")]
    public CourseSectionDtoLight Read(int id/*auth*/)
    => service.Read(id);

    [HttpPut("{id:int}")]
    public CourseSection Update(int id, CourseSectionInputDto dto /*auth*/) => service.Update(id, dto);

    [HttpDelete]
    public void Delete(int id /*auth*/) => service.Delete(id);
}

