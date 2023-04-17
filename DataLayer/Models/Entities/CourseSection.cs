using DataLayer.Models.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models.Entities;

public class CourseSection : Crud
{
    public virtual Term Term { get; set; }
    public virtual Instructor Instructor { get; set; }
    public virtual Course Course { get; set; }

    public virtual List<CourseSectionRegistration> CourseSectionRegistrations { get; set; }

}
