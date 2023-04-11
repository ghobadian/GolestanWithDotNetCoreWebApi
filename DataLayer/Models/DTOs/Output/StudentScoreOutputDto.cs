using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Output;

public class StudentScoreOutputDto : StudentOutputDto
{
    public double Score { get; init; }
}

