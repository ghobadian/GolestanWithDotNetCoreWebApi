using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Models.DTOs.Output;

public record StudentScoreOutputDto(int Id, string Username, string Name, string NationalId, string PhoneNumber,
    Degree Degree, DateOnly StartDate, double Score) : StudentOutputDto(Id, Username, Name, NationalId, PhoneNumber,
    Degree, StartDate);
