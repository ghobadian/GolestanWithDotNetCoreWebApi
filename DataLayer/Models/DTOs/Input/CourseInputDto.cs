﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Input;
public class CourseInputDto
{
    public string? Title { get; set; }
    public int? Units { get; set; }
}
