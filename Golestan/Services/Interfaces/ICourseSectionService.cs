using DataLayer.Models.DTOs;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Entities;

namespace Golestan.Services.Interfaces;
public interface ICourseSectionService : ICrudService<CourseSectionInputDto, CourseSectionOutputDto>
{
    IEnumerable<CourseSection> List(int termId, string instructorUsername, string courseTitle, int pageNumber, int pageSize);
    List<StudentScoreOutputDto> ListStudentsByCourseSection(int id, int pageNumber, int pageSize);
}

