using DataLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.Users
{
    public class Student : User
    {
        //[ForeignKey("User")]
        //public int Id { get; set; }
        [Required]
        public Degree Degree { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        public virtual User User { get; set; }

        public virtual List<CourseSectionRegistration> CourseSectionRegistrations { get;} = new List<CourseSectionRegistration>();
    }
}