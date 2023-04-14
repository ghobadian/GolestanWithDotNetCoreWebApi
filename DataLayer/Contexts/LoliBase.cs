using DataLayer.Models.Entities;
using DataLayer.Models.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Contexts
{
    public class LoliBase : DbContext
    {
        public LoliBase(DbContextOptions<LoliBase> options) : base(options)
        {
        }

        public LoliBase() { }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseSection> CourseSections { get; set; }
        public virtual DbSet<CourseSectionRegistration> CourseSectionRegistrations { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Term> Terms { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseSection>()
                .HasOne(p => p.Instructor)
                .WithMany()
                .HasForeignKey(p => p.InstructorForeignKey);
            modelBuilder.Entity<CourseSection>()
                .HasOne(p => p.Course)
                .WithMany()
                .HasForeignKey(p => p.CourseForeignKey);
            modelBuilder.Entity<CourseSection>()
                .HasOne(p => p.Term)
                .WithMany()
                .HasForeignKey(p => p.TermForeignKey);
            modelBuilder.Entity<CourseSection>()
                .HasAlternateKey(p => new {p.InstructorForeignKey, p.TermForeignKey, p.CourseForeignKey });
        }
    }
}
