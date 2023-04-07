using DataLayer.Models;
using DataLayer.Models.DTOs.Input;

namespace Golestan.Services.Interfaces;
public interface ICourseService : ICrudService<Course, CourseInputDto>
{
}

