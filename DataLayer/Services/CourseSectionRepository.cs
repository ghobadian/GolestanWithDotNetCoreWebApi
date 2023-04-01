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
    public class CourseSectionRepository : ICourseSectionRepository
    {
        private readonly LoliBase db;
        public CourseSectionRepository(LoliBase db) => this.db = db;

        public IEnumerable<CourseSection> GetAll()
        {
            return db.CourseSections;
        }

        public CourseSection GetById(int id)
        {
            return db.CourseSections.Single(entity => entity.Id == id);
        }

        public CourseSection Insert(CourseSection entity)
        {
            try
            {
                db.CourseSections.Add(entity);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public CourseSection Update(CourseSection entity)
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

        public bool Delete(CourseSection entity)
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
