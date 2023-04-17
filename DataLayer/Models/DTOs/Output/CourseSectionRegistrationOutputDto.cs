namespace DataLayer.Models.DTOs.Output;

public record CourseSectionRegistrationOutputDto(int Id, double? Score, string CourseName, string StudentUsername,
    string InstructorUsername, int StudentCount);
