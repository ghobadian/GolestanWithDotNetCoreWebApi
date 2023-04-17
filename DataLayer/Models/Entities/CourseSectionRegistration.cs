using DataLayer.Models.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.Entities;

public class CourseSectionRegistration : Crud
{
    public double? Score { get; set; }

    [Required]
    public int CourseSectionId { get; set; }
    [Required]
    public int StudentId { get; set; }
}
