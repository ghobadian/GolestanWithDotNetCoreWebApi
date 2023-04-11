using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;

namespace Golestan.Services.Interfaces;
public interface ICourseService : ICrudService<CourseInputDto, CourseOutputDto>
{
}

