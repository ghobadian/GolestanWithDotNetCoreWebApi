using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Entities;
using DataLayer.Models.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Services.Interfaces;
public interface IStudentService : ICrudService<StudentInputDto, StudentOutputDto>
{
    CourseSectionRegistrationOutputDto SignUpSection(int courseSectionId, [FromHeader] string token);
    StudentAverageDto SeeScoresInSpecifiedTerm(int termId, [FromHeader] string token);
    SummeryDto SeeSummery(string token);
    TokenOutputDto Login(string username, string password);

}

