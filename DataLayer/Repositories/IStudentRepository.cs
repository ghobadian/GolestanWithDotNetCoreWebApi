using DataLayer.Models;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        Student Insert(Student entity);
        Student Update(Student entity);
        bool Delete(int id);
        bool Delete(Student entity);
        void Save();
        void Dispose();
        Student FindByUsername(string username);
    }
}
