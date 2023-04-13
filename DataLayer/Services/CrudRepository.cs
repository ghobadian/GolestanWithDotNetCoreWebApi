using DataLayer.Contexts;
using DataLayer.Models.Entities;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace DataLayer.Services;

public class CrudRepository<T> : ICrudRepository<T> where T : class
{
    private readonly LoliBase db;

    private readonly DbSet<T> entities;
    //private readonly UserRepository<Course> ;
    public CrudRepository(LoliBase db)
    {
        this.db = db;
        entities = db.Set<T>();
    }

    public IEnumerable<T> GetAll(int pageNumber, int pageSize) => entities.ToPagedList(pageNumber, pageSize);

    public Course GetById(int id) => entities.Single(entity => entity.Id == id);

    public bool ExistsByTitle(string title)
        => entities.Any(entity => entity.Title == title);

    public void Dispose() => db.Dispose();

    public Course Update(Course entity)
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

    public bool Delete(int id) => Delete(GetById(id));

    public bool Delete(Course entity)
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

    public void Save() => db.SaveChanges();

    public Course Insert(Course entity)
    {
        try
        {
            entities.Add(entity);
            return entity;
        }
        catch (Exception)
        {
            return null;
        }
    }
}