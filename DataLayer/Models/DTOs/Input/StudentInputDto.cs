using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Input;

public record StudentInputDto
(string? Username, string? Password, string? Name, string? Phone, string? NationalId,
    Degree? Degree) : UserInputDto(Username, Password, Name, Phone, NationalId);
