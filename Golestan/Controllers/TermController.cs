using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
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
public class TermController {
    private readonly ITermService service;

    public TermController(ITermService service) => this.service = service;

    [HttpGet]//todo set status code for all actions
    [StudentAuthorize]//todo pagination
    public IEnumerable<Term> List(/*int page,*/ /*int number*/) => service.List(/*page, number*/);

    [HttpPost]
    [AdminAuthorize]
    //todo check if term exists
    public Term Create([FromBody] TermInputDto term, string token) => service.Create(term);

    [HttpGet("{id:int}")]
    [StudentAuthorize]
    public Term Read(int id, string token) => service.Read(id);

    [HttpPut("{id:int}")]
    [AdminAuthorize]
    public Term Update(int id,[FromBody] TermInputDto dto, string token) => service.Update(id, dto);
    //todo add from body to all input dtos

    [HttpDelete("{id:int}")]
    [AdminAuthorize]
    public void Delete(int id, string token) => service.Delete(id);
}
