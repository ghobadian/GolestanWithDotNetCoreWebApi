
using DataLayer.Enums;
using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Users;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Golestan.Services.Interfaces;
using Golestan.Utils;

namespace Golestan.Services;

public class StudentService : IStudentService {
    private readonly ICourseSectionRegistrationRepository csrRepository;
    private readonly IStudentRepository studentRepository;
    private readonly ITermRepository termRepository;
    private readonly ICourseSectionRepository courseSectionRepository;
    private readonly ICourseSectionRegistrationRepository courseSectionRegistrationRepository;
    private readonly IUserService userService;

    public StudentService(ICourseSectionRegistrationRepository csrRepository, 
        IStudentRepository studentRepository, 
        ITermRepository termRepository, 
        ICourseSectionRepository courseSectionRepository, 
        ICourseSectionRegistrationRepository courseSectionRegistrationRepository, 
        IUserService userService)
    {
        this.csrRepository = csrRepository;
        this.studentRepository = studentRepository;
        this.termRepository = termRepository;
        this.courseSectionRepository = courseSectionRepository;
        this.courseSectionRegistrationRepository = courseSectionRegistrationRepository;
        this.userService = userService;
    }

    private CourseSectionRegistration SignUpSection(Student student, CourseSection courseSection)
    {
        var csr = new CourseSectionRegistration
        {
            Student = student,
            CourseSection = courseSection
        };
        csrRepository.Insert(csr);
        csrRepository.Save();
        return csr;
    }

    public CourseSectionRegistration SignUpSection(int courseSectionId, string token)
    {
        string username = TokenRepository.GetById(token).UserName;
        return SignUpSection(studentRepository.FindByUsername(username), courseSectionRepository.GetById(courseSectionId));
    }

    public StudentAverageDto SeeScoresInSpecifiedTerm(int termId, string token)
    {
        string username = TokenRepository.GetById(token).UserName;//todo
        var student = studentRepository.FindByUsername(username);
        var courseSections = student.CourseSectionRegistrations
            .Select(csr => csr.CourseSection)
            .Where(cs => cs.Term.Id == termId)
            .Select(cs => new CourseSectionOutputDto{
                Id = cs.Id,
                CourseName = cs.Course.Title,
                CourseUnits = cs.Course.Units, 
                Instructor = new InstructorOutputDto{Name = cs.Instructor.Name, Rank = cs.Instructor.Rank}
            }).ToList();
        var average = student.CourseSectionRegistrations.Average(csr => csr.Score);
        return new StudentAverageDto{ Average = average, CourseSections = courseSections};
    }

    public SummeryDto SeeSummery(string token)
    {

        Student student = studentRepository.FindByUsername(TokenRepository.GetById(token).UserName);
        //AtomicReference<Double> totalSum = new AtomicReference<>((double) 0);//todo remove all comments
        double totalSum = 0;
        IEnumerable<Term> terms = termRepository.GetAll();
        var allTermDetails = new List<TermDetailsDto>();
        foreach (var term in terms)
        {
            var averageInSpecifiedTerm = FindAverageByTerm(term, student);
            var termDetails = new TermDetailsDto { Id = term.Id, Title = term.Title, StudentAverage = averageInSpecifiedTerm };
            totalSum += averageInSpecifiedTerm;
            allTermDetails.Add(termDetails);
        }

        return new SummeryDto { TermDetails = allTermDetails, TotalAverage = totalSum / terms.Count() };
    }


    private double FindAverageByTerm(Term term, Student student) => 
        courseSectionRegistrationRepository.FindByStudentIdAndTermId(student.Id, term.Id)
            .Average(csr => csr.Score);

    public IEnumerable<StudentOutputDto> List() => studentRepository.GetAll().Select(student => student.OutputDto());

    public StudentOutputDto Create(StudentInputDto dto)
    {
        var student = new Student();
        userService.CreateUserAspects(student, dto);
        studentRepository.Insert(student);
        studentRepository.Save();
        return student.OutputDto();
    }

    public StudentOutputDto Read(int id) => studentRepository.GetById(id).OutputDto();

    public StudentOutputDto Update(int id, StudentInputDto dto)
    {
        var student = studentRepository.GetById(id);
        userService.CreateUserAspects(student, dto);
        studentRepository.Update(student);
        studentRepository.Save();
        return student.OutputDto();
    }

    public void Delete(int studentId) {
        Student student = studentRepository.GetById(studentId);
        //todo test if it really deletes student from all csrs;
        //List<CourseSectionRegistration> csrs = repo.findCourseSectionRegistrationByStudent(student);
        //csrs.forEach(csr -> csr.setStudent(null));
        studentRepository.Delete(student);
        studentRepository.Save();
        //log.info("Student with id " + student + " created");
    }

    public TokenOutputDto Login(string username, string password)
    {
        CheckAuthority(username, password);
        var token = TokenGenerator.GenerateToken(Role.STUDENT, username);
        TokenRepository.Insert(token);
        return token.OutputDto();
    }

    private void CheckAuthority(string username, string password)
    {
        if (!studentRepository.ExistsByUsername(username)) throw new UsernameOrPasswordInvalidException();
        var student = studentRepository.FindByUsername(username);
        if (student.Password != PasswordEncoder.Encode(password)) throw new UsernameOrPasswordInvalidException();
        if (TokenRepository.ExistsByUsername(username)) throw new ReLoginException();
        //todo remove above duplicate code
    }
}