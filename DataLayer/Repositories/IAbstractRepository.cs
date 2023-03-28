using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IAbstractRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(int id);
        bool Delete(T entity);
        void Save();
        void Dispose();
    }
}
