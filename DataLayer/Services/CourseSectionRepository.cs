using DataLayer.Repositories;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;

namespace DataLayer.Services
{
    public class CourseSectionRepository : AllInOneRepository<CourseSection>
    {
        public CourseSectionRepository(LoliBase db) : base(db) { }

        public override IEnumerable<CourseSection> GetAll()
        {
            return db.CourseSections;
        }

        public override CourseSection GetById(int id)
        {
            return db.CourseSections.Single(entity => entity.Id == id);
        }

        public override bool Insert(CourseSection entity)
        {
            try
            {
                db.CourseSections.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
