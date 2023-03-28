using DataLayer.Models;
using DataLayer.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Contexts
{
    public class LoliBase : DbContext
    {
        public LoliBase(DbContextOptions<LoliBase> options) : base(options)
        {

        }

        public LoliBase() { }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseSection> CourseSections { get; set; }
        public virtual DbSet<CourseSectionRegistration> CourseSectionRegistrations { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Term> Terms { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }

    }
}
