using DataLayer.Models.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Entities
{
    public class CourseSectionRegistration
    {
        [Key]
        public int Id { get; set; }
        public double Score { get; set; }

        [Required]
        public virtual CourseSection CourseSection { get; set; }
        [Required]
        public virtual Student Student { get; set; }
    }
}