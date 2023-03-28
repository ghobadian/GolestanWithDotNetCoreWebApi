using DataLayer.Contexts;
using DataLayer.Models;

namespace DataLayer.Services
{
    public class CourseRepository : AllInOneRepository<Course>
    {
        public CourseRepository(LoliBase db) : base(db) { }

        public override IEnumerable<Course> GetAll()
        {
            return db.Courses;
        }

        public override Course GetById(int id)
        {
            return db.Courses.Single(entity => entity.Id == id);
        }

        public override bool Insert(Course entity)
        {
            try
            {
                db.Courses.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
