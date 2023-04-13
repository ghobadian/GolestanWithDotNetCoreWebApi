using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contexts;
using DataLayer.Models.Entities.Users;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace DataLayer.Services;
public class AdminRepository : IAdminRepository
{
    private readonly LoliBase db;
    public AdminRepository(LoliBase db) => this.db = db;

    public IEnumerable<Admin> GetAll(int pageNumber, int pageSize) => db.Admins.ToPagedList(pageNumber, pageSize);

    public Admin GetById(int id) => db.Admins.Single(entity => entity.Id == id);

    public Admin Insert(Admin entity)
    {
        try
        {
            db.Admins.Add(entity);
            return entity;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public Admin Update(Admin entity)
    {
        if (entity == null) { return default; }
        try
        {
            db.Entry(entity).State = EntityState.Modified;
            return entity;
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

    public bool Delete(Admin entity)
    {
        if (entity == null) return false;
        try
        {
            db.Entry(entity).State = EntityState.Deleted;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void Save()
    {
        db.SaveChanges();
    }

    public void Dispose()
    {
        db.Dispose();
    }

    public bool ExistsByNationalId(string nationalId)
    {
        throw new NotImplementedException();
    }

    public Admin FindByUsername(string UserName) => db.Admins.Single(admin => admin.UserName == UserName);
    public void Activate(int id)
    {
        var admin = new Admin() { Id = id, Active = true };
        db.Instructors.Attach(admin);
        db.Entry(admin).Property(x => x.Active).IsModified = true;
        Save();
    }

    public bool ExistsByUsername(string username) => db.Admins.Any(admin => admin.UserName == username);
    public bool ExistsById(int id) => db.Admins.Any(admin => admin.Id == id);
    public bool ExistsByPhone(string phone) => db.Admins.Any(admin => admin.PhoneNumber == phone);
}

