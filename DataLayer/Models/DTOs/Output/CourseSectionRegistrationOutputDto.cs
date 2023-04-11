namespace DataLayer.Models.DTOs.Output;

public record CourseSectionRegistrationOutputDto(int Id, double Score, CourseSectionOutputDto CourseSection,
    StudentOutputDto Student);
