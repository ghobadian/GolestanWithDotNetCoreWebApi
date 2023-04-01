using DataLayer.Models;
using DataLayer.Models.DTOs;
using DataLayer.Models.Users;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Services.Interfaces;

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

    public IEnumerable<CourseSection> List(int termId, string instructorName, string courseName/*, int page, int number*/) {
        var term = termRepository.GetById(termId);//todo optimize
        return courseSectionRepository.FindAllByTermAndInstructorUsernameAndCourseTitle(term, instructorName, courseName/*, PageRequest.of(page, number)*/);
    }

    public List<StudentDto> ListStudentsByCourseSection(int id) => 
        courseSectionRegistrationRepository.FindByCourseSectionId(id)
            .Select(GetStudentDetails).ToList();

    private static StudentDto GetStudentDetails(CourseSectionRegistration csr) 
    {
        var student = csr.Student;
        var user = student.User;
        return new StudentDto { Id = student.Id, Name = user.Name, Number = user.Phone, Score = csr.Score };
    }

    public CourseSection Create(int courseId, int instructorId, int termId)
    {
        var courseSection = BuildCourseSection(courseId, instructorId, termId);
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

    public CourseSection Update(int termId, int courseId, int instructorId, int courseSectionId)
    {
        CourseSection courseSection = courseSectionRepository.GetById(courseSectionId);
        UpdateTerm(termId, courseSection);
        UpdateCourse(courseId, courseSection);
        UpdateInstructor(instructorId, courseSection);
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
        //log.info("CourseSection " + cs + " Deleted");
        courseSectionRepository.Delete(id);
        courseSectionRepository.Save();
    }
}
