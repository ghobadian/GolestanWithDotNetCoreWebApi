using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Input;

public abstract record UserInputDto(string? Username, string? Password, string? Name, string? Phone, string? NationalId);
