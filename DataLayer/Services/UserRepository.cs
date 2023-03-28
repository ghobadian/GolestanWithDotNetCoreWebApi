using DataLayer.Repositories;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Services
{
    public class UserRepository : IUserRepository
    {
        LoliBase db;
        public UserRepository(LoliBase db)
        {
            this.db = db;
        }

        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public bool Delete(User entity)
        {
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

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<User> GetAll() => db.Users.Select(user => user);
        

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
