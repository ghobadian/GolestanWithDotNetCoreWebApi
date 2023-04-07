using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Input;
public class InstructorInputDto : UserInputDto
{
    public Rank? Rank { get; init; }
}
