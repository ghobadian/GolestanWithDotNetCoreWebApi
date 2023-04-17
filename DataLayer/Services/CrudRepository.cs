using DataLayer.Contexts;
using DataLayer.Models.Entities;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace DataLayer.Services;

public class CrudRepository<T> : ICrudRepository<T> where T : Crud
{
    protected readonly LoliBase db;

    protected DbSet<T> entities;
    public CrudRepository(LoliBase db)
    {
        this.db = db;
        entities = db.Set<T>();
    }

    public IEnumerable<T> GetAll(int pageNumber, int pageSize) => entities.ToPagedList(pageNumber, pageSize);

    public T GetById(int id) => entities.Single(entity => entity.Id == id);
    public bool ExistsById(int id) => entities.Any(entity => entity.Id == id);

    public void Dispose() => db.Dispose();

    public T Update(T entity)
    {
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

    public bool Delete(T entity)
    {
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

    public T Insert(T entity)
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