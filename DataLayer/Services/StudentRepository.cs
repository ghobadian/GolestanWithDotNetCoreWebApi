using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;
using DataLayer.Models.Entities.Users;
using PagedList;

namespace DataLayer.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly LoliBase db;
        public StudentRepository(LoliBase db) => this.db = db;

        public IEnumerable<Student> GetAll(int pageNumber, int pageSize) => db.Students.ToPagedList(pageNumber, pageSize);

        public Student GetById(int id) => db.Students.Single(entity => entity.Id == id);

        public Student Insert(Student entity)
        {
            try
            {
                db.Students.Add(entity);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Student Update(Student entity)
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

        public bool Delete(int id) => Delete(GetById(id));

        public bool Delete(Student entity)
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

        public void Save() => db.SaveChanges();

        public void Dispose() => db.Dispose();

        public bool ExistsByUsername(string username) => db.Students.Any(entity => entity.UserName == username);
        public Student FindByUsername(string username) => db.Students.Single(entity => entity.UserName == username);
    }
}
