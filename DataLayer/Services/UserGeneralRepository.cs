using DataLayer.Contexts;
using DataLayer.Models.Entities.Users;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Services;

public class UserGeneralRepository<T> : GeneralRepository<T> where T : User, new()
{
    public UserGeneralRepository(LoliBase db) : base(db)
    {
        this.db = db;
    }

    public void Activate(int id)
    {
        T user = new T() { Id = id, Active = true};
        db.Entry(user).Property(x => x.Active).IsModified = true;
        DbSet<T> set = db.Set<T>();
        set.Attach(user);
        db.Entry(user).Property(x => x.Active).IsModified = true;
        Save();
    }

    public void Save()
    {
        db.SaveChanges();
    }


}