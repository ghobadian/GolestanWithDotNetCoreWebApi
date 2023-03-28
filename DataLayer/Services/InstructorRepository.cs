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
    public class InstructorRepository : AllInOneRepository<Instructor>
    {
        public InstructorRepository(LoliBase db) : base(db) { }

        public override IEnumerable<Instructor> GetAll()
        {
            return db.Instructors;
        }

        public override Instructor GetById(int id)
        {
            return db.Instructors.Single(entity => entity.Id == id);
        }

        public override bool Insert(Instructor entity)
        {
            try
            {
                db.Instructors.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
