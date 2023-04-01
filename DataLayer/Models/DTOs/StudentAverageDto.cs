using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs;
public class StudentAverageDto
{
    public double Average { get; init; }
    public List<CourseSectionDto> CourseSections { get; init; }
}

