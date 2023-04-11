using DataLayer.Models;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Users;

namespace Golestan.Utils;

public static class ExtensionMethods//todo change its name. it's tooooooo general
{
    public static TokenOutputDto OutputDto(this Token token) => new() { Token = token.Value, ValidUntil = token.ValidUntil };
    public static AdminOutputDto OutputDto(this Admin admin) => 
        new() { Id = admin.Id, Name = admin.Name, NationalId = admin.NationalId, 
            PhoneNumber = admin.PhoneNumber, UserName = admin.UserName};

    public static StudentOutputDto OutputDto(this Student student) =>
        new()
        {
            Id = student.Id, Degree = student.Degree, UserName = student.UserName, Name = student.Name,
            NationalId = student.NationalId, PhoneNumber = student.PhoneNumber, StartDate = student.StartDate
        };

    public static InstructorOutputDto OutputDto(this Instructor instructor) =>
        new()
        {
            Id = instructor.Id, Name = instructor.Name, NationalId = instructor.NationalId,
            PhoneNumber = instructor.PhoneNumber, Rank = instructor.Rank, UserName = instructor.UserName
        };

    public static CourseOutputDto OutputDto(this Course course) => new()
    {
        Id = course.Id, Title = course.Title, Units = course.Units
    };

    public static CourseSectionOutputDto OutputDto(this CourseSection courseSection) => new()
    {
        Id = courseSection.Id, CourseName = courseSection.Course.Title, CourseUnits = courseSection.Course.Units,
        Instructor = courseSection.Instructor.OutputDto(),
        NumberOfStudents = courseSection.CourseSectionRegistrations.Count
    };

    public static CourseSectionRegistrationOutputDto OutputDto(this CourseSectionRegistration csr) => new()
    {
        Id = csr.Id, CourseSection = csr.CourseSection.OutputDto(), Score = csr.Score, Student = csr.Student.OutputDto()
    };

    public static TermOutputDto OutputDto(this Term term) => new()
    {
        Id = term.Id, Title = term.Title
    };

    public static bool IsInvalid(this Token token) => DateTime.Compare(token.ValidUntil, DateTime.Now) < 0;
}