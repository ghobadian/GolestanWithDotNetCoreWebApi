using DataLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.Users
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Degree Degree { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId; 
        [Required]
        public virtual User User { get; set; }

        public virtual List<CourseSectionRegistration> CourseSectionRegistrations { get;} = new List<CourseSectionRegistration>();
    }
}