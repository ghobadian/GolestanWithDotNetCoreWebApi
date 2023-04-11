using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Output;
public class CourseSectionOutputDto
{
    public int Id { get; init; }
    public string CourseName { get; init; }
    public int CourseUnits { get; init; }
    public InstructorOutputDto Instructor { get; init; }
    public int NumberOfStudents { get; set; }

    //public double Score { get; init; }//todo why use this?
}

