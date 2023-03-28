using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Course
    {
        [Key] 
        public int Id { get; set; }
        public string Title { get; set; }
        public int Units { get; set; }
        public virtual List<CourseSection> CourseSections { get; set; }
    }
}