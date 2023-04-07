using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using Golestan.Services;
using Golestan.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
public class TermController {
    private readonly ITermService service;

    public TermController(ITermService service) => this.service = service;

    [HttpGet]
    public IEnumerable<Term> List(/*int page,*/ /*int number*/) => service.List(/*page, number*/);

    [HttpPost]
    public Term Create([FromBody] TermInputDto term/*auth*/) => service.Create(term);

    [HttpGet("{id:int}")]
    public Term Read(int id/*auth*/) => service.Read(id);

    
    [HttpPut("{id:int}")]
    public Term Update(int id,[FromBody] TermInputDto dto /*auth*/) => service.Update(id, dto);
    //todo add from body to all input dtos

    [HttpDelete("{id:int}")]
    public void Delete(int id/*auth*/) => service.Delete(id);
}
