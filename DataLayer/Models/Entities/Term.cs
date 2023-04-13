using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Entities
{
    public class Term
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Open { get; set; }
        public virtual List<CourseSection> CourseSections { get; set; }
    }
}