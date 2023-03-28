using DataLayer.Repositories;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;

namespace DataLayer.Services
{
    public class StudentRepository : AllInOneRepository<Student>
    {
        public StudentRepository(LoliBase db) : base(db) { }

        public override IEnumerable<Student> GetAll()
        {
            return db.Students;
        }

        public override Student GetById(int id)
        {
            return db.Students.Single(entity => entity.Id == id);
        }

        public override bool Insert(Student entity)
        {
            try
            {
                db.Students.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Student FindByUsername(string username) => 
            db.Students.Single(entity => entity.User.Username == username);
    }
}
