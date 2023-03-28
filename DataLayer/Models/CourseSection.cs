using DataLayer.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class CourseSection
    {
        [Key]
        public int Id { get; set; }
        public virtual Term Term { get; set; }
        public virtual Instructor Instructor { get; set; }
        public virtual Course Course { get; set; }

        public virtual List<CourseSectionRegistration> CourseSectionRegistrations { get; set; }
        
    }
}