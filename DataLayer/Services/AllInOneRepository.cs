using DataLayer.Contexts;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public abstract class AllInOneRepository<T> : IAbstractRepository<T>
    {

        protected readonly LoliBase db;
        public AllInOneRepository(LoliBase db)
        {
            this.db = db;
        }

        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public bool Delete(T entity)
        {
            if(entity == null) return false;
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

        public void Dispose() => db.Dispose();

        public abstract IEnumerable<T> GetAll();

        public abstract T GetById(int id);

        public abstract bool Insert(T entity);

        public void Save()
        {
            db.SaveChanges();
        }

        public bool Update(T entity)
        {
            if (entity == null) { return false; }
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
