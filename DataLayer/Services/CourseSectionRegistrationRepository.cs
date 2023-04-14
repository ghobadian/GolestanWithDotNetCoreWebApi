using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;
using DataLayer.Models.Entities.Users;
using DataLayer.Models.Entities;
using PagedList;

namespace DataLayer.Services
{
    public class CourseSectionRegistrationRepository : CrudRepository<CourseSectionRegistration>, ICourseSectionRegistrationRepository
    {
        public CourseSectionRegistrationRepository(LoliBase db) : base(db)
        {
        }

        public CourseSectionRegistration FindByCourseSectionIdAndStudentId(int courseSectionId, int studentId) =>
            entities.Single(csr => csr.CourseSection.Id == courseSectionId && csr.Student.Id == studentId);

        public bool ExistsByCourseSectionIdAndStudentId(int courseSectionId, int studentId) => entities.Any(csr =>
            csr.CourseSection.Id == courseSectionId && csr.Student.Id == studentId);

        public IEnumerable<CourseSectionRegistration> FindByStudent(Student student) =>
            entities.Where(csr => csr.Student.Equals(student));

        public int CountByCourseSectionId(int courseSectionId) =>
            FindByCourseSectionId(courseSectionId).Count();
        public IEnumerable<CourseSectionRegistration> FindByCourseSectionId(int courseSectionId) =>
            entities.Where(csr => csr.CourseSection.Id == courseSectionId);

        public IEnumerable<CourseSectionRegistration> FindByStudentIdAndTermId(int studentId, int termId) =>
            entities.Where(csr =>
                csr.Student.Id == studentId && csr.CourseSection.Term.Id == termId);
    }
}
