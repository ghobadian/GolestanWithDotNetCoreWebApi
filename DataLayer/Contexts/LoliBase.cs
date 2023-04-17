using DataLayer.Models.Entities;
using DataLayer.Models.Entities.Users;
//using Microsoft.AspNetCore.Identity;//todo re
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
            UniqueConstraint(modelBuilder);
        }

        private static void UniqueConstraint(ModelBuilder modelBuilder)
        {
            CourseSectionUniqueConstraints(modelBuilder);
            CourseSectionRegistrationUniqueConstraints(modelBuilder);
            modelBuilder.Entity<Term>().HasIndex(u => u.Title).IsUnique();
        }

        private static void CourseSectionRegistrationUniqueConstraints(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseSectionRegistration>()
                .HasIndex(p => new
                {
                    CourseSection = p.CourseSectionId, Student = p.StudentId
                }).IsUnique();
        }

        private static void CourseSectionUniqueConstraints(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseSection>()
                .Property(cs => cs.Course)
                .HasConversion(t => t.Id, id => new Course() { Id = id });

            modelBuilder.Entity<CourseSection>()
                .Property(cs => cs.Instructor)
                .HasConversion(t => t.Id, id => new Instructor() { Id = id });

            modelBuilder.Entity<CourseSection>()
                .Property(cs => cs.Term)
                .HasConversion(t => t.Id, id => new Term() { Id = id });

            modelBuilder.Entity<CourseSection>()
                .HasIndex(p => new
                {
                    p.Course,
                    p.Instructor,
                    p.Term
                }).IsUnique();
        }
    }
}
