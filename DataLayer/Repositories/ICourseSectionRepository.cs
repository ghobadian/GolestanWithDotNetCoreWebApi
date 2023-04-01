using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ICourseSectionRepository : IDisposable
    {
        IEnumerable<CourseSection> GetAll();
        CourseSection GetById(int id);
        CourseSection Insert(CourseSection entity);
        CourseSection Update(CourseSection entity);
        bool Delete(int id);
        bool Delete(CourseSection entity);
        void Save();
        void Dispose();

        public IEnumerable<CourseSection> FindByTerm(Term term);
        public bool ExistsByIdAndTerm(int id, Term term);
        public IEnumerable<CourseSection> FindAllByTermAndInstructorUsernameAndCourseTitle(Term term, string username, string courseTitle);
        public IEnumerable<CourseSection> FindByInstructorId(int instructorId);

    }
}
