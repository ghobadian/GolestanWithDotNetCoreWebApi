using DataLayer.Models;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ICourseSectionRegistrationRepository : IDisposable
    {
        IEnumerable<CourseSectionRegistration> GetAll();
        CourseSectionRegistration GetById(int id);
        CourseSectionRegistration Insert(CourseSectionRegistration entity);
        CourseSectionRegistration Update(CourseSectionRegistration entity);
        bool Delete(int id);
        bool Delete(CourseSectionRegistration entity);
        void Save();
        void Dispose();

        CourseSectionRegistration FindByCourseSectionIdAndStudentId(int courseSectionId, int studentId);
        bool ExistsByCourseSectionIdAndStudentId(int courseSectionId, int studentId);
        IEnumerable<CourseSectionRegistration> FindByStudent(Student student);
        int CountByCourseSectionId(int courseSectionId);
        IEnumerable<CourseSectionRegistration> FindByCourseSectionId(int courseSectionId);

        IEnumerable<CourseSectionRegistration> FindByStudentIdAndTermId(int studentId, int termId);
    }
}
