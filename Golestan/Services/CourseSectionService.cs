using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Users;
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
    private readonly IInstructorRepository instructorRepository;

    public CourseSectionService(ICourseSectionRepository courseSectionRepository,
        ITermRepository termRepository, 
        ICourseSectionRegistrationRepository courseSectionRegistrationRepository, 
        ICourseRepository courseRepository, 
        IInstructorRepository instructorRepository)
    {
        this.courseSectionRepository = courseSectionRepository;
        this.termRepository = termRepository;
        this.courseSectionRegistrationRepository = courseSectionRegistrationRepository;
        this.courseRepository = courseRepository;
        this.instructorRepository = instructorRepository;
    }

    public IEnumerable<CourseSectionOutputDto> List() => courseSectionRepository.GetAll().Select(cs => cs.OutputDto());

    public IEnumerable<CourseSection> List(int termId, string instructorUsername, string courseTitle/*, int page, int number*/) =>
        courseSectionRepository
            .FindAllByTermIdAndInstructorUsernameAndCourseTitle(termId, instructorUsername, courseTitle/*, PageRequest.of(page, number)*/);

    public List<StudentScoreOutputDto> ListStudentsByCourseSection(int id) => 
        courseSectionRegistrationRepository.FindByCourseSectionId(id)
            .Select(GetStudentDetails).ToList();

    private static StudentScoreOutputDto GetStudentDetails(CourseSectionRegistration csr)
    {
        var student = (StudentScoreOutputDto) csr.Student.OutputDto();
        return  student with { Score = csr.Score };
    }

    public CourseSection Create(CourseSectionInputDto dto)
    {
        var courseSection = BuildCourseSection(dto.CourseId, dto.InstructorId, dto.TermId);
        //log.info("CourseSection " + courseSection + "created");
        var insertedCourseSection = courseSectionRepository.Insert(courseSection);
        courseSectionRepository.Save();
        return insertedCourseSection;
    }

    private CourseSection BuildCourseSection(int courseId, int instructorId, int termId) => 
        new()
        { Course = courseRepository.GetById(courseId), 
            Instructor = instructorRepository.GetById(instructorId),
            Term = termRepository.GetById(termId)

        };

    public CourseSectionDtoLight Read(int id)
    {
        var courseSection = courseSectionRepository.GetById(id);
        var numberOfStudents = courseSection.CourseSectionRegistrations.Count;
        return new CourseSectionDtoLight { CourseSection = courseSection, NumberOfStudents = numberOfStudents };
    }

    public CourseSection Update(int id, CourseSectionInputDto dto)
    {
        var courseSection = courseSectionRepository.GetById(id);
        UpdateTerm(dto.TermId, courseSection);
        UpdateCourse(dto.CourseId, courseSection);
        UpdateInstructor(dto.InstructorId, courseSection);
        courseSectionRepository.Update(courseSection);
        courseSectionRepository.Save();
        return courseSection;
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
        //log.info("CourseSection " + service + " Deleted");
        courseSectionRepository.Delete(id);
        courseSectionRepository.Save();
    }
}
