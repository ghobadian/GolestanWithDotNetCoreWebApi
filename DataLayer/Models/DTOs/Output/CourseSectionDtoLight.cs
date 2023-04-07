using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Output;
public class CourseSectionDtoLight
{
    public CourseSection CourseSection { get; init; }
    public int NumberOfStudents { get; set; }
}

