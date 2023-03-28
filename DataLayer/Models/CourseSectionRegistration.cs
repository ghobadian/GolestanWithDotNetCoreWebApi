using DataLayer.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class CourseSectionRegistration
    {
        [Key]
        public int Id { get; set; }
        public double Score { get; set; }
        
        public virtual CourseSection CourseSection { get; set; }
        public virtual Student Student { get; set; }
    }
}