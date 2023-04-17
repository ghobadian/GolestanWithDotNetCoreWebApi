using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models.Entities
{
    public class Term : Crud
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public bool Open { get; set; }
        public virtual List<CourseSection> CourseSections { get; set; }
    }
}