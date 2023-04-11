using DataLayer.Models;
using DataLayer.Models.DTOs;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;

namespace Golestan.Services.Interfaces;
public interface ICourseSectionService : ICrudService<CourseSectionInputDto, CourseSectionOutputDto>
{
    IEnumerable<CourseSection> List(int termId, string instructorUsername, string courseTitle);
    List<StudentScoreOutputDto> ListStudentsByCourseSection(int id);
}

