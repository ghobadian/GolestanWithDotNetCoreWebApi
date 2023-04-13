using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Entities;
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
public class TermController : ControllerBase, ICrudController<TermInputDto, TermOutputDto>
{
    private readonly ITermService service;

    public TermController(ITermService service) => this.service = service;

    
    [HttpGet]//todo set status code for all actions
    [StudentAuthorize]
    public IEnumerable<TermOutputDto> List([FromHeader] string token, int pageNumber = 1, int pageSize = 100) => service.List(pageNumber, pageSize);

    [HttpPost]
    [AdminAuthorize]
    //todo check if term exists
    public TermOutputDto Create([FromBody] TermInputDto term, [FromHeader] string token) => service.Create(term);

    [HttpGet("{id:int}")]
    [StudentAuthorize]
    public TermOutputDto Read(int id, [FromHeader] string token) => service.Read(id);

    [HttpPut("{id:int}")]
    [AdminAuthorize]
    public TermOutputDto Update(int id,[FromBody] TermInputDto dto, [FromHeader] string token) => service.Update(id, dto);
    //todo add from body to all input dtos

    [HttpDelete("{id:int}")]
    [AdminAuthorize]
    public void Delete(int id, [FromHeader] string token) => service.Delete(id);
}
