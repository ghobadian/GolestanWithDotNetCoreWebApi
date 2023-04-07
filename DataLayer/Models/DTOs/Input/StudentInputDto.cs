using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Input;
public class StudentInputDto : UserInputDto
{
    public Degree? Degree { get; init; }
    public DateOnly? StartDate { get; init; }
}
