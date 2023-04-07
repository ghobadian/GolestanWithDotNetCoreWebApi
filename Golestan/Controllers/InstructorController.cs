using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Users;
using Golestan.Aspects;
using Golestan.Services;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")] 
public class InstructorController {
    public readonly InstructorService service;

    public InstructorController(InstructorService service) => this.service = service;

    [HttpGet]
    [InstructorAuthorize]
    public IEnumerable<Instructor> List(/*int page, */ /*int number*/string token) => service.List();

    [HttpGet("{id:int}")]
    [InstructorAuthorize, SpecificInstructorAuthorize]
    public Instructor Read(int id, [FromHeader] string token) => service.Read(id);

    [HttpDelete("{id:int}")]
    [InstructorAuthorize, SpecificInstructorAuthorize]
    public void Delete(int id, [FromHeader] string token) => service.Delete(id);
    
    [HttpPut("{id:int}")]
    [InstructorAuthorize, SpecificInstructorAuthorize]
    public Instructor Update(int id, InstructorInputDto dto, [FromHeader] string token) => service.Update(id, dto);

    [HttpPost("{courseSectionId:int}/{studentId:int}/{score:double}")]
    
    public CourseSectionRegistration GiveMark(int courseSectionId, int studentId, double score, [FromHeader] string token) => 
        service.GiveMark(courseSectionId, studentId, score);

    [HttpPost("{courseSectionId:int}")]
    [SpecificInstructorAuthorize]
    public List<CourseSectionRegistration> GiveMultipleMarks(int courseSectionId, [FromBody] Dictionary<int, double> idsAndScores, [FromHeader] string token) => 
        service.GiveMultipleMarks(courseSectionId, idsAndScores);

    [HttpPost]
    public TokenOutputDto Login([FromHeader] string username, [FromHeader] string password) => service.Login(username, password);
}
