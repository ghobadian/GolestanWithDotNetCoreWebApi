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
    public class CourseSectionRegistrationRepository : ICourseSectionRegistrationRepository
    {
        private readonly LoliBase db;
        public CourseSectionRegistrationRepository(LoliBase db) => this.db = db;

        public IEnumerable<CourseSectionRegistration> GetAll(int pageNumber, int pageSize) => db.CourseSectionRegistrations.ToPagedList(pageNumber, pageSize);

        public CourseSectionRegistration GetById(int id)
        {
            return db.CourseSectionRegistrations.Single(entity => entity.Id == id);
        }

        public CourseSectionRegistration Insert(CourseSectionRegistration entity)
        {
            try
            {
                db.CourseSectionRegistrations.Add(entity);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        

        public CourseSectionRegistration Update(CourseSectionRegistration entity)
        {
            if (entity == null) { return default; }
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                return entity;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public bool Delete(CourseSection? entity)
        {
            if (entity == null) return false;
            try
            {
                db.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }

        public bool Delete(CourseSectionRegistration? entity)
        {
            if (entity == null) return false;
            try
            {
                db.Entry(entity).State = EntityState.Deleted;
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

        public IEnumerable<CourseSectionRegistration> FindByStudentIdAndTermId(int studentId, int termId) =>
            db.CourseSectionRegistrations.Where(csr =>
                csr.Student.Id == studentId && csr.CourseSection.Term.Id == termId);
    }
}
