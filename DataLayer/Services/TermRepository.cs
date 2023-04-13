using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;
using DataLayer.Models.Entities.Users;
using DataLayer.Models.Entities;
using PagedList;

namespace DataLayer.Services
{
    public class TermRepository : ITermRepository
    {
        private readonly LoliBase db;
        public TermRepository(LoliBase db) => this.db = db;

        public IEnumerable<Term> GetAll() => db.Terms;

        public IEnumerable<Term> GetAll(int pageNumber, int pageSize) => db.Terms.ToPagedList(pageNumber, pageSize);

        public Term GetById(int id)
        {
            return db.Terms.Single(entity => entity.Id == id);
        }

        public Term Insert(Term entity)
        {
            try
            {
                db.Terms.Add(entity);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Term Update(Term entity)
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

        public bool Delete(Term entity)
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
        public bool ExistsByTitle(string title) => db.Terms.Any(entity => entity.Title == title);

        public bool ExistsById(int id) => db.Terms.Any(term => term.Id == id);

    }
}
