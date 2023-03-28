using DataLayer.Repositories;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Contexts;
using DataLayer.Models.Users;

namespace DataLayer.Services
{
    public class CourseSectionRegistrationRepository : AllInOneRepository<CourseSectionRegistration>
    {
        public CourseSectionRegistrationRepository(LoliBase db) : base(db) { }

        public override IEnumerable<CourseSectionRegistration> GetAll()
        {
            return db.CourseSectionRegistrations;
        }

        public override CourseSectionRegistration GetById(int id)
        {
            return db.CourseSectionRegistrations.Single(entity => entity.Id == id);
        }

        public override bool Insert(CourseSectionRegistration entity)
        {
            try
            {
                db.CourseSectionRegistrations.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public CourseSectionRegistration FindByCourseSectionIdAndStudentId(int courseSectionId, int studentId)
        {
            return db.CourseSectionRegistrations.Single(csr => csr.CourseSection.Id == courseSectionId && csr.Student.Id == studentId);
        }

        public bool ExistsByCourseSectionIdAndStudentId(int courseSectionId, int studentId) => 
            db.CourseSectionRegistrations
            .Any(csr => csr.CourseSection.Id == courseSectionId && csr.Student.Id == studentId);

        public IEnumerable<CourseSectionRegistration> FindByStudent(Student student) => 
            db.CourseSectionRegistrations.Where(csr => csr.Student.Equals(student));

        public int CountByCourseSectionId(int courseSectionId) => 
            FindByCourseSectionId(courseSectionId).Count();
        public IEnumerable<CourseSectionRegistration> FindByCourseSectionId(int courseSectionId) =>
            db.CourseSectionRegistrations.Where(csr => csr.CourseSection.Id == courseSectionId);
    }
}
