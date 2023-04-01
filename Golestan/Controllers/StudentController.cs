using DataLayer.Models;
using DataLayer.Models.DTOs;
using Golestan.Services;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

public class StudentController {
    public readonly StudentService service;

    [HttpPost("{courseSectionId:int}")]
    public CourseSectionRegistration SignUpSection(int courseSectionId /*auth*/) {
        return service.SignUpSection(courseSectionId);
    }


    [HttpGet("{termId:int}")]
    public StudentAverageDto SeeScoresInSpecifiedTerm(/*request_param*/ int termId /*auth*/, string token) => 
        service.SeeScoresInSpecifiedTerm(termId, token);

    [HttpGet]
    public SummeryDto SeeSummery(/*auth*/) {
        return service.SeeSummery();
    }
}
