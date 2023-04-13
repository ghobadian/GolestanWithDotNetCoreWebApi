using DataLayer.Contexts;
using DataLayer.Models.Entities;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace DataLayer.Services
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LoliBase db;
        private readonly UserGeneralRepository<Course> ;
        public CourseRepository(LoliBase db) => this.db = db;

        public IEnumerable<Course> GetAll(int pageNumber, int pageSize) => db.Courses.ToPagedList(pageNumber, pageSize);

        public Course GetById(int id) => db.Courses.Single(entity => entity.Id == id);

        public bool ExistsByTitle(string title)
        => db.Courses.Any(entity => entity.Title == title);

        public void Dispose() => db.Dispose();

        public Course Update(Course entity)
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

        public bool Delete(Course entity)
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

        public Course Insert(Course entity)
        {
            try
            {
                db.Courses.Add(entity);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ExistsById(int id) => db.Instructors.Any(instructor => instructor.Id == id);

    }
}
