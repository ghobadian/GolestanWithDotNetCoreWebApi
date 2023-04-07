using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Users;

namespace Golestan.Services.Interfaces;
public interface IStudentService : ICrudService<Student, StudentInputDto>
{
    TokenOutputDto Login(string username, string password);

}

