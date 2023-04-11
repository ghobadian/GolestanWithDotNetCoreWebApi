using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Users;

namespace Golestan.Services.Interfaces;
public interface IStudentService : ICrudService<StudentInputDto, StudentOutputDto>
{
    CourseSectionRegistration SignUpSection(int courseSectionId, string token);
    StudentAverageDto SeeScoresInSpecifiedTerm(int termId, string token);
    SummeryDto SeeSummery(string token);
    TokenOutputDto Login(string username, string password);

}

