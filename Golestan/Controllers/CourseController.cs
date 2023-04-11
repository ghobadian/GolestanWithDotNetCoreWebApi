using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.Users;
using Golestan.Aspects.ExceptionHandling;
using Golestan.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
[HandleExceptions]
public class CourseController : ControllerBase
{

    public readonly ICourseService service;
    public CourseController(ICourseService service) => this.service = service;

    //public readonly CourseSecurityService securityService;


    //public List<Course> List(int page, int number)
    //{
    //	return service.List(page, number);
    //}

    [HttpGet]
    public IEnumerable<Course> List() => service.List();

    [HttpPost]
    public Course Create(CourseInputDto dto) => service.Create(dto);

    [HttpGet("{id:int}")]
    public Course Read(int id) => service.Read(id);

    [HttpPut("{id:int}")]
    public Course Update(int id, CourseInputDto dto) => service.Update(id, dto);


    [HttpDelete("{id:int}")]
    public void Delete(int id) => service.Delete(id);
}

