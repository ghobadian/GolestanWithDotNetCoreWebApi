using DataLayer.Enums;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Input;
public class CourseSectionInputDto
{
    public int TermId { get; init; }
    public int InstructorId { get; init; }
    public int CourseId { get; init; }
}
