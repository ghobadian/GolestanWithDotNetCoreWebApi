using DataLayer.Models.DTOs;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Entities;
using DataLayer.Models.Entities.Users;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.IdentityModel.Tokens;

namespace Golestan.Utils;

public static class ExtensionMethods//todo change its name. it's tooooooo general
{
    public static TokenOutputDto OutputDto(this Token token) => new(token.Value, token.ValidUntil);
    public static AdminOutputDto OutputDto(this Admin admin) => 
        new(admin.Id, admin.UserName, admin.Name, admin.NationalId, admin.PhoneNumber);

    public static StudentOutputDto OutputDto(this Student student) =>
        new(student.Id, student.UserName, student.Name, student.NationalId, student.PhoneNumber, student.Degree,
            student.StartDate);

    public static InstructorOutputDto OutputDto(this Instructor instructor) =>
        new(instructor.Id, instructor.UserName, instructor.Name, instructor.NationalId, instructor.PhoneNumber, instructor.Rank);

    public static CourseOutputDto OutputDto(this Course course) => new(course.Id, course.Title, course.Units);

    public static CourseSectionOutputDto OutputDto(this CourseSection courseSection) => new(courseSection.Id,
        courseSection.Course.Title,
        courseSection.Course.Units, courseSection.Instructor.OutputDto(),
        courseSection.CourseSectionRegistrations.IsNullOrEmpty() ? 0 : courseSection.CourseSectionRegistrations.Count);

    public static CourseSectionRegistrationOutputDto OutputDto(this CourseSectionRegistration csr) => new(csr.Id,
        csr.Score, csr.CourseSection.OutputDto(), csr.Student.OutputDto());

    public static TermOutputDto OutputDto(this Term term) => new(term.Id, term.Title);

    public static bool IsInvalid(this Token token) => DateTime.Compare(token.ValidUntil, DateTime.Now) < 0;
}