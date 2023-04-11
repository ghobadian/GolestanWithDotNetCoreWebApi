using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Output;
public class InstructorOutputDto : UserOutputDto
{
    public Rank Rank { get; init; }
}

