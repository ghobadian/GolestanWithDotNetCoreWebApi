using DataLayer.Contexts;
using DataLayer.Models.Entities.Users;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace DataLayer.Services;

public class UserRepository<T> : IUserRepository<T> where T : User, new()
{
    private LoliBase db;
    private DbSet<T> users;

    public UserRepository(LoliBase db)
    {
        this.db = db;
        users = db.Set<T>();
    }

    public void Activate(int id)
    {
        T user = new T() { Id = id, Active = true};
        db.Entry(user).Property(x => x.Active).IsModified = true;
        users.Attach(user);
        db.Entry(user).Property(x => x.Active).IsModified = true;
        Save();
    }

    public void Save()
    {
        db.SaveChanges();
    }

    public T Insert(T user)
    {
        try
        {
            users.Add(user);
            return user;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public T Update(T user)
    {
        try
        {
            db.Entry(user).State = EntityState.Modified;
            return user;
        }
        catch (Exception)
        {
            return default;
        }
    }

    public bool Delete(int id)
    {
        return Delete(GetById(id));
    }

    public bool Delete(T user)
    {
        try
        {
            db.Entry(user).State = EntityState.Deleted;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IEnumerable<T> GetAll(int pageNumber, int pageSize) => users.ToPagedList(pageNumber, pageSize);

    public T GetById(int id) => users.Single(entity => entity.Id == id);

    public bool ExistsByNationalId(string nationalId) => users.Any(user => user.NationalId == nationalId);

    public T FindByUsername(string username) => users.Single(user => user.UserName == username);
    public bool ExistsByUsername(string username) => users.Any(user => user.UserName == username);
    public bool ExistsById(int id) => users.Any(user => user.Id == id);
    public bool ExistsByPhone(string phone) => users.Any(user => user.PhoneNumber == phone);
    public void Dispose() => db.Dispose();
}