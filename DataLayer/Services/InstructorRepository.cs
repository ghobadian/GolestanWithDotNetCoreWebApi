using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;
using DataLayer.Models;
using DataLayer.Models.Entities.Users;
using PagedList;

namespace DataLayer.Services
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly LoliBase db;
        private readonly 
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

        public IEnumerable<Instructor> GetAll(int pageNumber, int pageSize) => db.Instructors.ToPagedList(pageNumber, pageSize);

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
        public bool ExistsByUsername(string username) => db.Instructors.Any(instructor => instructor.UserName == username);
        public Instructor FindByUsername(string username) => db.Instructors.Single(instructor => instructor.UserName == username);

        public void Activate(int id)
        {
            var instructor = new Instructor() { Id = id, Active = true };
            db.Instructors.Attach(instructor);
            db.Entry(instructor).Property(x => x.Active).IsModified = true;
            Save();
        }
    }
}
