using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Output;
public class SummeryDto
{
    public List<TermDetailsDto> TermDetails { get; init; }
    public double TotalAverage { get; init; }
}

