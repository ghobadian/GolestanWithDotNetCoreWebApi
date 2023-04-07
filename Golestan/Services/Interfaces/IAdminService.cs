using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Users;

namespace Golestan.Services.Interfaces;
public interface IAdminService : ICrudService<Admin, AdminInputDto>
{
    TokenOutputDto Login(string username, string password);
}
