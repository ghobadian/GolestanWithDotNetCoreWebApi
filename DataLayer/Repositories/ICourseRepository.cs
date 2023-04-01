using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ICourseRepository : IDisposable
    {
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        Course Insert(Course entity);//todo return entity instead of bool
        Course Update(Course entity);
        bool Delete(int id);
        bool Delete(Course entity);
        void Save();
        void Dispose();
        public bool ExistsById(int id);
    }
}
