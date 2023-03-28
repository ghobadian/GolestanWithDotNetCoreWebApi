using DataLayer.Repositories;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Services
{
    public class TermRepository : ITermRepository
    {
        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public bool Delete(Term entity)
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
            throw new NotImplementedException();
        }

        public IEnumerable<Term> GetAll()
        {
            throw new NotImplementedException();
        }

        public Term GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Term entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Term entity)
        {
            throw new NotImplementedException();
        }
    }
}
