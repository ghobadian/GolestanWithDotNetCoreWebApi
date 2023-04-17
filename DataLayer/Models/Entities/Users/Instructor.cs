using DataLayer.Enums;

namespace DataLayer.Models.Entities.Users
{
    public class Instructor : User
    {
        public Rank Rank { get; set; }

        public virtual List<CourseSection> CourseSections { get; set; }

    }
}