using DataLayer.Models;
using DataLayer.Models.DTOs.Output;
using Golestan.Aspects;
using Golestan.Services;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
public class StudentController {
    public readonly StudentService service;

    public StudentController(StudentService service)
    {
        this.service = service;
    }

    //todo implement crud

    [HttpPost("{courseSectionId:int}")]
    [StudentAuthorize]
    //todo extra authorization for not active users
    public CourseSectionRegistration SignUpSection(int courseSectionId, [FromHeader] string token) => service.SignUpSection(courseSectionId);//todo fix in service


    [HttpGet("{termId:int}")]
    [StudentAuthorize]
    public StudentAverageDto SeeScoresInSpecifiedTerm( int termId, [FromHeader] string token) => 
        service.SeeScoresInSpecifiedTerm(termId, token);

    [HttpGet]
    [StudentAuthorize]
    public SummeryDto SeeSummery([FromHeader] string token) => service.SeeSummery(token);

    [HttpPost]
    public TokenOutputDto Login([FromHeader] string username, [FromHeader] string password) => service.Login(username, password);
}
