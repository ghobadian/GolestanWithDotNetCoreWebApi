using DataLayer.Models;
using Golestan.Services;
using Golestan.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

public class TermController {
    private readonly ITermService service;

    public TermController(ITermService service)
    {
        this.service = service;
    }


    [HttpGet]
    public IEnumerable<Term> List(/*auth*//*request_param*/ /*int page,*/ /*request_param*/ /*int number*/) {
        return service.List(/*page, number*/);
    }

    
    [HttpPost]
    public Term Create(/*request_param*/ string title, bool open/*auth*/) {
        return service.Create(title, open);
    }

    [HttpGet("{id:int}")]
    public Term Read(int id/*auth*/) {
        return service.Read(id);
    }

    
    [HttpPut("{id:int}")]
    public Term Update(/*request_param*//*(required = false)*/ string title,
                          /*request_param*//*(required = false)*/ bool open,
                          int id
                          /*auth*/) {
        return service.Update(title, open, id);
    }

    
    [HttpDelete("{id:int}")]
    public void Delete(int id/*auth*/) {
        service.Delete(id);
    }
}
