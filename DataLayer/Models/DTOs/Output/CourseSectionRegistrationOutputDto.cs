namespace DataLayer.Models.DTOs.Output;

public class CourseSectionRegistrationOutputDto
{
    public int Id { get; set; }
    public double Score { get; set; }
    public CourseSectionOutputDto CourseSection { get; set; }
    public virtual StudentOutputDto Student { get; set; }
}