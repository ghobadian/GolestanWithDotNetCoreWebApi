
using DataLayer.Models;
using DataLayer.Models.DTOs;
using DataLayer.Models.Users;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Runtime.InteropServices;
using Golestan.Services;
using Golestan.Services.Interfaces;

namespace Golestan.Controllers
{
    public class CourseSectionController
    {
        private readonly ICourseSectionService service;

        public CourseSectionController(ICourseSectionService service)
        {
            this.service = service;
        }

        [HttpGet("{termId:int}")]
        public IEnumerable<CourseSection> List(/*request_param*/ int termId,
                                         /*auth*/
                                          string instructorName,
                                         string courseName
                                         /*Integer pageNumber,*/
                                          /*Integer maxInEachPage*/) {
        return service.List(termId, instructorName, courseName/*, pageNumber, maxInEachPage*/);
        }

        [HttpGet]
        public List<StudentDto> ListStudentsOfSpecifiedCourseSection(/*request_param*/ int courseSectionId
                                                                     /*auth*/)
        {
            //todo only instructor of the course section have access and ofcourse admin
            return service.ListStudentsByCourseSection(courseSectionId);
        }

        [HttpPost]
        public CourseSection Create(/*request_param*/ int courseId,
                              /*request_param*/ int instructorId,
                              /*request_param*/ int termId
                              /*auth*/)
        {
            return service.Create(courseId, instructorId, termId);
        }

        
        [HttpGet]
        public CourseSectionDtoLight Read(int id/*auth*/)
        {
            return service.Read(id);
        }

        
        [HttpPut("{id:int}")]
        public CourseSection Update(/*request_param*//*(required = false)*/ int termId,
                                     /*request_param*//*(required = false)*/ int courseId,
                                     /*request_param*//*(required = false)*/ int instructorId,
                                     int id
                                     /*auth*/) {
            return service.Update(termId, courseId, instructorId, id);
        }


        [HttpDelete]
        public void Delete(int id
                            /*auth*/)
    {
        service.Delete(id);
    }
}
}
