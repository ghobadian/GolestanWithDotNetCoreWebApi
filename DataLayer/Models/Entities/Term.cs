using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Entities
{
    public class Term : Crud
    {
        public string Title { get; set; }
        public bool Open { get; set; }
        public virtual List<CourseSection> CourseSections { get; set; }
    }
}