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

        public IEnumerable<CourseSection> FindByTerm(Term term) => 
            db.CourseSections.Where(entity => entity.Term == term);

        public bool ExistsByIdAndTerm(int id, Term term) => 
            db.CourseSections.Any(entity => entity.Id == id && entity.Term == term);

        public IEnumerable<CourseSection> FindAllByTermAndInstructorUsernameAndCourseTitle(Term term, string username, string courseTitle) =>
            db.CourseSections.Where(entity => entity.Term == term && entity.Instructor.User.Username == username && entity.Course.Title == courseTitle);
        
        public IEnumerable<CourseSection> FindByInstructorId(int instructorId) => 
            db.CourseSections.Where(entity => entity.Instructor.Id == instructorId);
    }
}
