using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Output;
public class TermDetailsDto : TermOutputDto
{
    public double StudentAverage { get; init; }
}

