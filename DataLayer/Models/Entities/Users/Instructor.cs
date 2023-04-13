using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Enums;

namespace DataLayer.Models.Entities.Users
{
    public class Instructor : User
    {
        //[ForeignKey("User")]
        //public int Id { get; set; }

        public Rank Rank { get; set; }

        //public virtual User User { get; set; }

        public virtual List<CourseSection> CourseSections { get; set; }

    }
}