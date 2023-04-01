using DataLayer.Models;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Insert(User entity);
        User Update(User entity);
        bool Delete(int id);
        bool Delete(User entity);
        void Save();
        void Dispose();

        User FindByUsername(string username);

        User FindByStudentId(int studentId);

        User FindByInstructorId(int instructorId);
        IEnumerable<User> FindByAdminTrue();

        bool ExistsByInstructorId(int instructorId);

        bool ExistsByPhone(string phone);

        bool ExistsByUsername(string username);

        bool ExistsByNationalId(string nationalId);
    }
}
