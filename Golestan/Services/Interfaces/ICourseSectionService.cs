using DataLayer.Models;
using DataLayer.Models.DTOs;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;

namespace Golestan.Services.Interfaces;
public interface ICourseSectionService//todo implement ICrudService you lazy loser
{
    IEnumerable<CourseSection> List();
    IEnumerable<CourseSection> List(int termId, string instructorUsername, string courseTitle);
    CourseSection Create(CourseSectionInputDto dto);
    CourseSectionDtoLight Read(int id);
    CourseSection Update(int id, CourseSectionInputDto dto);
    void Delete(int id);
    List<StudentDto> ListStudentsByCourseSection(int id);
}

