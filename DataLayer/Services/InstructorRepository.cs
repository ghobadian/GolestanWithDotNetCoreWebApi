using DataLayer.Repositories;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Services
{
    public class InstructorRepository : IInstructorRepository
    {
        public bool Delete(int id)
        {
            try
            {
                db.Entry(GetById(id)).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Instructor entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Instructor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Instructor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Instructor entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Instructor entity)
        {
            throw new NotImplementedException();
        }
    }
}
