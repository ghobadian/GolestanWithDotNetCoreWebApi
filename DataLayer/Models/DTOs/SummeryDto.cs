using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs;
public class SummeryDto
{
    public List<TermDto> TermDetails { get; init; }
    public double TotalAverage { get; init; }
}

