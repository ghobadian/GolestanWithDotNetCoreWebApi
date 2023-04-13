using DataLayer.Enums;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Entities;
using DataLayer.Models.Entities.Users;
using DataLayer.Repositories;
using DataLayer.Services;

namespace Golestan.Services.Interfaces;

public interface IInstructorService : ICrudService<InstructorInputDto, InstructorOutputDto>
{
    CourseSectionRegistration GiveMark(int courseSectionId, int studentId, double score);
    List<CourseSectionRegistration> GiveMultipleMarks(int courseSectionId,
        Dictionary<int, double> idsAndScoresJson);
    TokenOutputDto Login(string username, string password);

}