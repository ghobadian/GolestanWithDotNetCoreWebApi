using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Entities.Users;

namespace Golestan.Services.Interfaces;
public interface IAdminService : ICrudService<AdminInputDto, AdminOutputDto>
{
    TokenOutputDto Login(string username, string password);
    void ActivateAdmin(int adminId);
    void ActivateInstructor(int instructorId);
    void ActivateStudent(int studentId);
}
