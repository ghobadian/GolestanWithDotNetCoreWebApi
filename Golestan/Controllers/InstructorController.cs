using DataLayer.Enums;
using DataLayer.Models;
using DataLayer.Models.Users;
using Golestan.Services;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

public class InstructorController {
    public readonly InstructorService service;

    public InstructorController(InstructorService service)
    {
        this.service = service;
    }
    
    [HttpGet]
    public IEnumerable<Instructor> List(/*auth*//*, *//*request_param*/ /*int page, *//*request_param*/ /*int number*/)
    {
        return service.List();
    }

    
    [HttpGet]
    public Instructor Read(int id/*auth*/) {
        return service.Read(id);
    }

    
    [HttpDelete]
    public void Delete(int instructorId/*auth*/) {
        service.Delete(instructorId);
    }

    
    [HttpPut]
    public Instructor Update(/*request_param*/ Rank rank, int instructorId/*auth*/) {
        return service.Update(rank, instructorId);
    }

    [HttpPost]
    public CourseSectionRegistration GiveMark(/*request_param*/ int courseSectionId,
                                              int studentId,
                                              /*request_param*/ double score
                                              /*auth*/) {
        return service.GiveMark(courseSectionId, studentId, score);
    }

    [HttpPost]
    public List<CourseSectionRegistration> GiveMultipleMarks(/*request_param*/ int courseSectionId,
                                                             /*request_param*/ Dictionary<int, double> idsAndScores
                                                             /*auth*/) {
        return service.GiveMultipleMarks(courseSectionId, idsAndScores);
    }
}
