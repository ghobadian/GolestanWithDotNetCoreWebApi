using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Enums;

namespace DataLayer.Models.Users
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        public Rank Rank { get; set; }  
        [ForeignKey("User")]
        public int UserId;
        public virtual User User { get; set; }
        public virtual List<CourseSection> CourseSections { get; set; }

    }
}