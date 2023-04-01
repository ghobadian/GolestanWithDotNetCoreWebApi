using DataLayer.Models;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IInstructorRepository : IDisposable
    {
        IEnumerable<Instructor> GetAll();
        Instructor GetById(int id);
        Instructor Insert(Instructor entity);
        Instructor Update(Instructor entity);
        bool Delete(int id);
        bool Delete(Instructor entity);
        void Save();
        void Dispose();
        public bool ExistsById(int id);
    }
}
