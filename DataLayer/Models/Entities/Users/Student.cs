using DataLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.Entities.Users
{
    public class Student : User
    {
        [Required]
        public Degree Degree { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        public virtual List<CourseSectionRegistration> CourseSectionRegistrations { get; } = new List<CourseSectionRegistration>();
    }
}