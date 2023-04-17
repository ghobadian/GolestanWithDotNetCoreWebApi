using DataLayer.Models.Entities.Users;

namespace DataLayer.Repositories;

public interface IUserRepository<T> : ICrudRepository<T>
{
    bool ExistsById(int id);
    bool ExistsByPhone(string phone); 
    bool ExistsByUsername(string username);
    bool ExistsByNationalId(string  nationalId);
    T FindByUsername(string username);
    public void Activate(int id);
    
}