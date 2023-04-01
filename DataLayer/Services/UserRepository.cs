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
    public class UserRepository : IUserRepository
    {
        private readonly LoliBase db;
        public UserRepository(LoliBase db) => this.db = db;

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User GetById(int id)
        {
            return db.Users.Single(entity => entity.Id == id);
        }

        public User Insert(User entity)
        {
            try
            {
                db.Users.Add(entity);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User Update(User entity)
        {
            if (entity == null) { return default; }
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

        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public bool Delete(User entity)
        {
            if (entity == null) return false;
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

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public User FindByUsername(string username) => db.Users.Single(user => user.Username == username);

        public User FindByStudentId(int studentId) => db.Users.Single(user => user.Student.Id == studentId);

        public User FindByInstructorId(int instructorId) => db.Users.Single(user => user.Instructor.Id == instructorId);
        public IEnumerable<User> FindByAdminTrue() => db.Users.Where(user => user.Admin);

        public bool ExistsByInstructorId(int instructorId) => db.Users.Any(user => user.Instructor.Id == instructorId);

        public bool ExistsByPhone(string phone) => db.Users.Any(user => user.Phone == phone);

        public bool ExistsByUsername(string username) => db.Users.Any(user => user.Username.Equals(username));

        public bool ExistsByNationalId(string nationalId) => db.Users.Any(user => user.NationalId.Equals(nationalId));
    }
}
