using DataLayer.Models.DTOs.Input;
using DataLayer.Models.Entities.Users;

namespace Golestan.Services.Interfaces
{
    public interface IUserService
    {
        public void CreateUserAspects(User user, UserInputDto newUser);
    }
}
