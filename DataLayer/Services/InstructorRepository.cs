using DataLayer.Repositories;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;
using DataLayer.Models;

namespace DataLayer.Services
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly LoliBase db;
        public InstructorRepository(LoliBase db) => this.db = db;

        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public bool Delete(Instructor entity)
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

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Instructor> GetAll()
        {
            return db.Instructors;
        }

        public Instructor GetById(int id)
        {
            return db.Instructors.Single(entity => entity.Id == id);
        }

        public Instructor Insert(Instructor entity)
        {
            try
            {
                db.Instructors.Add(entity);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Instructor Update(Instructor entity)
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

        public bool ExistsById(int id) => db.Instructors.Any(instructor => instructor.Id == id);
    }
}
