using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Entities;
using DataLayer.Models.Entities.Users;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Services.Interfaces;
using Golestan.Utils;

namespace Golestan.Services;

public class CourseSectionService : ICourseSectionService
{
    private readonly ICourseRepository courseRepository;
    private readonly ICourseSectionRepository courseSectionRepository;
    private readonly ICourseSectionRegistrationRepository courseSectionRegistrationRepository;
    private readonly ITermRepository termRepository;
    private readonly IUserRepository<Instructor> instructorRepository;
    private readonly IUserRepository<Student> studentRepository;
    private readonly ILogger<CourseSectionService> logger;

    public CourseSectionService(ICourseSectionRepository courseSectionRepository,
        ITermRepository termRepository, 
        ICourseSectionRegistrationRepository courseSectionRegistrationRepository, 
        ICourseRepository courseRepository, 
        IUserRepository<Instructor> instructorRepository, 
        ILogger<CourseSectionService> logger)
    {
        this.courseSectionRepository = courseSectionRepository;
        this.termRepository = termRepository;
        this.courseSectionRegistrationRepository = courseSectionRegistrationRepository;
        this.courseRepository = courseRepository;
        this.instructorRepository = instructorRepository;
        this.logger = logger;
    }

    public IEnumerable<CourseSectionOutputDto> List(int pageNumber, int pageSize)
    {
        return courseSectionRepository.GetAll(pageNumber, pageSize).Select(cs => cs.OutputDto(instructorRepository, courseRepository));
    }

    public IEnumerable<CourseSection> List(int termId, string instructorUsername, string courseTitle, int pageNumber, int pageSize) =>
        courseSectionRepository
            .FindAllByTermIdAndInstructorUsernameAndCourseTitle(termId, instructorUsername, courseTitle, pageNumber, pageSize);

    public List<StudentScoreOutputDto> ListStudentsByCourseSection(int id, int pageNumber, int pageSize) => 
        courseSectionRegistrationRepository.FindByCourseSectionId(id)
            .Select(csr => GetStudentDetails(csr, studentRepository)).ToList();

    private static StudentScoreOutputDto GetStudentDetails(CourseSectionRegistration csr, IUserRepository<Student> studentRepository)
    {
        var dto = studentRepository.GetById(csr.StudentId).OutputDto();//todo test casting again
        return new StudentScoreOutputDto(dto.Id, dto.Username, dto.Name, dto.NationalId, dto.PhoneNumber, dto.Degree,
            dto.StartDate, csr.Score);
    }

    public CourseSectionOutputDto Create(CourseSectionInputDto dto)
    {
        var courseSection = BuildCourseSection(dto.CourseId, dto.InstructorId, dto.TermId);
        logger.LogInformation("CourseSectionId \" + courseSection + \"created");;
        var insertedCourseSection = courseSectionRepository.Insert(courseSection);
        courseSectionRepository.Save();
        return insertedCourseSection.OutputDto(instructorRepository, courseRepository);
    }

    private CourseSection BuildCourseSection(int courseId, int instructorId, int termId) => 
        new()
        { Course = courseRepository.GetById(courseId), 
            Instructor = instructorRepository.GetById(instructorId),
            Term = termRepository.GetById(termId)
        };

    public CourseSectionOutputDto Read(int id) => courseSectionRepository.GetById(id).OutputDto(instructorRepository, courseRepository);

    public CourseSectionOutputDto Update(int id, CourseSectionInputDto dto)
    {
        var courseSection = courseSectionRepository.GetById(id);
        UpdateTerm(dto.TermId, courseSection);
        UpdateCourse(dto.CourseId, courseSection);
        UpdateInstructor(dto.InstructorId, courseSection);
        courseSectionRepository.Update(courseSection);
        courseSectionRepository.Save();
        return courseSection.OutputDto(instructorRepository, courseRepository);
    }

    private void UpdateInstructor(int instructorId, CourseSection courseSection)
    {
        if (!instructorRepository.ExistsById(instructorId)) return;
        var instructor = instructorRepository.GetById(instructorId);
        courseSection.Instructor = instructor;
    }

    private void UpdateCourse(int courseId, CourseSection courseSection)
    {
        if (!courseRepository.ExistsById(courseId)) return;
        var course = courseRepository.GetById(courseId);
        courseSection.Course = course;
    }

    private void UpdateTerm(int termId, CourseSection courseSection)
    {
        if (!termRepository.ExistsById(termId)) return;
        var term = termRepository.GetById(termId);
        courseSection.Term = term;
    }

    public void Delete(int id)
    {
        logger.LogInformation("CourseSectionId \" + service + \" Deleted");
        courseSectionRepository.Delete(id);
        courseSectionRepository.Save();
    }
}
