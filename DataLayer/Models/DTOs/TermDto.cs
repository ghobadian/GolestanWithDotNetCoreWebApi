using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs;
public class TermDto
{
    public int TermId { get; init; }
    public string TermTitle { get; init; }
    public double StudentAverage { get; init; }
}

