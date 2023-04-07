using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Output;

public class StudentDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Number { get; init; }
    public double Score { get; init; }
}

