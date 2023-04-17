using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Entities;
using DataLayer.Services;
using Golestan.Aspects.Authorize;
using Golestan.Aspects.ExceptionHandling;
using Golestan.Services;
using Golestan.Services.Interfaces;
using Golestan.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
[HandleExceptions]
public class InstructorController : ControllerBase, ICrudController<InstructorInputDto, InstructorOutputDto>
{
    public readonly IInstructorService service;

    public InstructorController(IInstructorService service) => this.service = service;

    [HttpPost("{courseSectionId:int}/{studentId:int}/{score:double}")]
    [SpecificInstructorAuthorize]
    public CourseSectionRegistrationOutputDto GiveMark(int courseSectionId, int studentId, double score, [FromHeader] string token) => 
        service.GiveMark(courseSectionId, studentId, score);

    [HttpPost("{courseSectionId:int}")]
    [SpecificInstructorAuthorize]
    public IEnumerable<CourseSectionRegistrationOutputDto> GiveMultipleMarks(int courseSectionId, [FromBody] Dictionary<int, double> idsAndScores, [FromHeader] string token) => 
        service.GiveMultipleMarks(courseSectionId, idsAndScores);

    [HttpPost]
    public TokenOutputDto Login([FromHeader] string username, [FromHeader] string password) => service.Login(username, password);

    [HttpGet]
    [InstructorAuthorize]
    public IEnumerable<InstructorOutputDto> List([FromHeader] string token, int pageNumber = 1, int pageSize = 100) => service.List(pageNumber, pageSize);

    [HttpPost]
    public InstructorOutputDto Create([FromBody] InstructorInputDto dto, [FromHeader] string? token) => service.Create(dto);

    [HttpGet("{id:int}")]
    [SpecificInstructorAuthorize]
    public InstructorOutputDto Read(int id, [FromHeader] string token) => service.Read(id);

    [HttpPut]
    [SpecificInstructorAuthorize]
    public InstructorOutputDto Update(int id, [FromBody] InstructorInputDto dto, [FromHeader] string token) => service.Update(id, dto);

    [HttpDelete]
    [SpecificInstructorAuthorize]
    public void Delete(int id, [FromHeader] string token) => service.Delete(id);
}
