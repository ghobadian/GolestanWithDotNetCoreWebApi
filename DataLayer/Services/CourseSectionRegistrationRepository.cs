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
using System.Runtime.ConstrainedExecution;

namespace DataLayer.Services
{
    public class CourseSectionRegistrationRepository : CrudRepository<CourseSectionRegistration>, ICourseSectionRegistrationRepository
    {
        private readonly ICourseSectionRepository courseSectionRepository;
        public CourseSectionRegistrationRepository(LoliBase db, ICourseSectionRepository courseSectionRepository) : base(db)
        {
            this.courseSectionRepository = courseSectionRepository;
        }

        public CourseSectionRegistration FindByCourseSectionIdAndStudentId(int courseSectionId, int studentId) =>
            entities.Single(csr => csr.CourseSectionId == courseSectionId && csr.StudentId == studentId);


        public bool ExistsByCourseSectionIdAndStudentId(int courseSectionId, int studentId) => entities.Any(csr =>
            csr.CourseSectionId == courseSectionId && csr.StudentId == studentId);

        public IEnumerable<CourseSectionRegistration> FindByStudent(Student student) =>
            entities.Where(csr => csr.StudentId.Equals(student));

        public int CountByCourseSectionId(int courseSectionId) =>
            FindByCourseSectionId(courseSectionId).Count();
        public IEnumerable<CourseSectionRegistration> FindByCourseSectionId(int courseSectionId) =>
            entities.Where(csr => csr.CourseSectionId == courseSectionId);

        public IEnumerable<CourseSectionRegistration> FindByStudentIdAndTermId(int studentId, int termId)
        {
            var courseSectionRegistrations = entities.Where(csr => csr.StudentId == studentId);
            List<CourseSectionRegistration> outputs = new List<CourseSectionRegistration>();
            foreach (var courseSectionRegistration in courseSectionRegistrations)
            {
                var courseSection = courseSectionRepository.GetById(courseSectionRegistration.CourseSectionId);
                if (courseSection.Term.Id == termId)
                {
                    outputs.Add(courseSectionRegistration);
                }
            }
            return outputs;
            //var results = courseSectionRegistrations
            //    .Join(db.CourseSections,
            //        registration => registration.CourseSectionId,
            //        section => section.Instructor.Id, (registration, section) => new
            //        {
            //            CourseSectionRegistration = registration,
            //            TermId = section.Term.Id
            //        });
            //var resultsFilterdByTermId = results.Where(jointResult => jointResult.TermId == termId);
        }

    }
}
