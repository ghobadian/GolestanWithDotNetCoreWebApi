using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Units { get; set; }
        public virtual List<CourseSection> CourseSections { get; set; }
    }
}