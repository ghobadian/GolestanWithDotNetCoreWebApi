using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;
using DataLayer.Models.Entities;
using PagedList;

namespace DataLayer.Services
{
    public class CourseSectionRepository : CrudRepository<CourseSection>, ICourseSectionRepository
    {
        public CourseSectionRepository(LoliBase db) : base(db) {}

        public IEnumerable<CourseSection> FindByTerm(Term term) =>
            entities.Where(entity => entity.Term == term);

        public bool ExistsByIdAndTerm(int id, Term term) =>
            entities.Any(entity => entity.Id == id && entity.Term == term);

        public IEnumerable<CourseSection> FindAllByTermIdAndInstructorUsernameAndCourseTitle(int termId, string UserName, string courseTitle, int pageNumber, int pageSize) =>
            entities.Where(entity => entity.Term.Id == termId && entity.Instructor.UserName == UserName && entity.Course.Title == courseTitle);

        public IEnumerable<CourseSection> FindByInstructorId(int instructorId) =>
            entities.Where(entity => entity.Instructor.Id == instructorId);
    }
}
