using DataLayer.Models.Users;

namespace DataLayer.Repositories;

public interface ICrudRepository<T> : IDisposable
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    T Insert(T entity);
    T Update(T entity);
    bool Delete(int id);
    bool Delete(T entity);
    void Save();
}