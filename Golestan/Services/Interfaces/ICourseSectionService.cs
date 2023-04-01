using DataLayer.Models;
using DataLayer.Models.DTOs;

namespace Golestan.Services.Interfaces;
public interface ICourseSectionService
{
    IEnumerable<CourseSection> List(int termId, string instructorName, string courseName);
    List<StudentDto> ListStudentsByCourseSection(int id);
    CourseSection Create(int courseId, int instructorId, int termId);
    CourseSectionDtoLight Read(int id);
    CourseSection Update(int termId, int courseId, int instructorId, int courseSectionId);
    public void Delete(int id);
}

