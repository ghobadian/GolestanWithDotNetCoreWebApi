using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Output;

public record CourseSectionOutputDto(int Id, string CourseName, int CourseUnits, InstructorOutputDto Instructor,
    int NumberOfStudents);
//public double Score { get; init; }//todo why use this?

