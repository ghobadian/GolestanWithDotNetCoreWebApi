using DataLayer.Repositories;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using System.Runtime.InteropServices;

namespace DataLayer.Services
{
    public class UserRepository : AllInOneRepository<User>
    {
        public UserRepository(LoliBase db) : base(db) { }

        public override IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public override User GetById(int id)
        {
            return db.Users.Single(entity => entity.Id == id);
        }

        public override bool Insert(User entity)
        {
            try
            {
                db.Users.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        User FindByUsername(string username) => db.Users.Single(user => user.Username == username); 

        User FindByStudentId(int studentId) => db.Users.Single(user => user.Student.Id == studentId);

        public User FindByInstructorId(int instructorId) => db.Users.Single(user => user.Instructor.Id == instructorId);
        public IEnumerable<User> FindByAdminTrue() => db.Users.Where(user => user.Admin);

        public bool ExistsByInstructorId(int instructorId) => db.Users.Any(user => user.Instructor.Id == instructorId);

        public bool ExistsByPhone(string phone) => db.Users.Any(user => user.Phone == phone);

        public bool ExistsByUsername(string username) => db.Users.Any(user => user.Username.Equals(username));

        public bool ExistsByNationalId(string nationalId) => db.Users.Any(user => user.NationalId.Equals(nationalId));
    }
}
