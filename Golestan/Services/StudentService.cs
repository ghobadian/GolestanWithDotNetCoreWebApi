
using DataLayer.Models;
using DataLayer.Models.DTOs;
using DataLayer.Models.Users;
using DataLayer.Repositories;
using Golestan.Services.Interfaces;

namespace Golestan.Services;

public class StudentService : IStudentService {
    private readonly ICourseSectionRegistrationRepository csrRepository;
    private readonly IStudentRepository studentRepository;
    private readonly ITermRepository termRepository;
    private readonly ICourseSectionRepository courseSectionRepository;
    private readonly ICourseSectionRegistrationRepository courseSectionRegistrationRepository;

    public StudentService(ICourseSectionRegistrationRepository csrRepository, 
        IStudentRepository studentRepository, 
        ITermRepository termRepository, 
        ICourseSectionRepository courseSectionRepository, 
        ICourseSectionRegistrationRepository courseSectionRegistrationRepository)
    {
        this.csrRepository = csrRepository;
        this.studentRepository = studentRepository;
        this.termRepository = termRepository;
        this.courseSectionRepository = courseSectionRepository;
        this.courseSectionRegistrationRepository = courseSectionRegistrationRepository;
    }

    public CourseSectionRegistration SignUpSection(Student student, CourseSection courseSection)
    {
        CourseSectionRegistration csr = new CourseSectionRegistration
        {
            Student = student,
            CourseSection = courseSection
        };
        csrRepository.Insert(csr);
        csrRepository.Save();
        return csr;
    }

    public CourseSectionRegistration SignUpSection(int courseSectionId/*, string token*/)
    {
        string username = null;//todo
        return SignUpSection(studentRepository.FindByUsername(username), courseSectionRepository.GetById(courseSectionId));
    }

    public StudentAverageDto SeeScoresInSpecifiedTerm(int termId, string token)
    {
        string username = null;//todo
        var student = studentRepository.FindByUsername(username);
        var courseSections = student.CourseSectionRegistrations
            .Select(csr => csr.CourseSection)
            .Select(cs => new CourseSectionDto{
                Id = cs.Id,
                CourseName = cs.Course.Title,
                CourseUnits = cs.Course.Units, 
                Instructor = new InstructorDto{Name = cs.Instructor.User.Name, Rank = cs.Instructor.Rank}
            }).ToList();
        var average = student.CourseSectionRegistrations.Average(csr => csr.Score);
        return new StudentAverageDto{ Average = average, CourseSections = courseSections};
    }

    public SummeryDto SeeSummery(/*string token*/)
    {
        Student student = null;//todo
        //AtomicReference<Double> totalSum = new AtomicReference<>((double) 0);
        double totalSum = 0;
        IEnumerable<Term> terms = termRepository.GetAll();
        var allTermDetails = new List<TermDto>();
        foreach (var term in terms)
        {
            var averageInSpecifiedTerm = findAverageByTerm(term, student);
            var termDetails = new TermDto { TermId = term.Id, TermTitle = term.Title, StudentAverage = averageInSpecifiedTerm };
            totalSum += averageInSpecifiedTerm;
            allTermDetails.Add(termDetails);
        }

        return new SummeryDto { TermDetails = allTermDetails, TotalAverage = totalSum / terms.Count() };
    }


    private double findAverageByTerm(Term term, Student student) => 
        courseSectionRegistrationRepository.FindByStudentIdAndTermId(student.Id, term.Id)
            .Average(csr => csr.Score);

    public void Delete(int studentId) {
        Student student = studentRepository.GetById(studentId);
        //todo test if it really deletes student from all csrs;
        //List<CourseSectionRegistration> csrs = repo.findCourseSectionRegistrationByStudent(student);
        //csrs.forEach(csr -> csr.setStudent(null));
        studentRepository.Delete(student);
        studentRepository.Save();
        //log.info("Student with id " + student + " created");
    }
}