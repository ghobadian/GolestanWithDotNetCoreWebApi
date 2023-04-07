using DataLayer.Models;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ICourseSectionRegistrationRepository : ICrudRepository<CourseSectionRegistration>
    {

        CourseSectionRegistration FindByCourseSectionIdAndStudentId(int courseSectionId, int studentId);
        bool ExistsByCourseSectionIdAndStudentId(int courseSectionId, int studentId);
        IEnumerable<CourseSectionRegistration> FindByStudent(Student student);
        int CountByCourseSectionId(int courseSectionId);
        IEnumerable<CourseSectionRegistration> FindByCourseSectionId(int courseSectionId);

        IEnumerable<CourseSectionRegistration> FindByStudentIdAndTermId(int studentId, int termId);
    }
}
