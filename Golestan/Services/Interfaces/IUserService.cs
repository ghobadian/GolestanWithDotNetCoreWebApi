using DataLayer.Models.DTOs.Input;
using DataLayer.Models.Users;

namespace Golestan.Services.Interfaces
{
    public interface IUserService
    {
        public void CreateUserAspects(User user, UserInputDto newUser);
    }
}
