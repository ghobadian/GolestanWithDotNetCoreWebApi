using DataLayer.Enums;

namespace DataLayer.Models.DTOs.Output;

public class StudentOutputDto : UserOutputDto
{
    public Degree Degree { get; set; }
    public DateOnly StartDate { get; set; }
}