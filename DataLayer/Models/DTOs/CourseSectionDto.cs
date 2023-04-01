﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs;
public class CourseSectionDto
{
    public int Id { get; init; }
    public string CourseName { get; init; }
    public int CourseUnits { get; init; }
    public InstructorDto Instructor { get; init; }
    public double Score { get; init; }
}

