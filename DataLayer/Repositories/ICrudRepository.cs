using System.Linq.Expressions;
using DataLayer.Models.Entities.Users;

namespace DataLayer.Repositories;

public interface ICrudRepository<T> : IDisposable
{
    IEnumerable<T> GetAll(int pageNumber, int pageSize);//todo read from config
    T GetById(int id);
    T Insert(T entity);
    T Update(T entity);
    bool Delete(int id);
    bool Delete(T entity);
    void Save();
}