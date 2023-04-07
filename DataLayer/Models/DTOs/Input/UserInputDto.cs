using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Input;
public abstract class UserInputDto
{
    public string? Username { get; init; }
    public string? Password { get; init; }
    public string? Name { get; init; }
    public string? Phone { get; init; }
    public string? NationalId { get; init; }
}
