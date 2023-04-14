using DataLayer.Contexts;
using DataLayer.Models.Entities;
using DataLayer.Repositories;

namespace DataLayer.Services
{
    public class CourseRepository : CrudRepository<Course>, ICourseRepository
    {
        public CourseRepository(LoliBase db) : base(db)
        {
        }

        public bool ExistsByTitle(string title) => entities.Any(course => course.Title == title);
        
    }
}
