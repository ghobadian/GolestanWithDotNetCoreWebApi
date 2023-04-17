using DataLayer.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.DTOs.Output;

public record StudentOutputDto(int Id, string Username, string Name, string NationalId, string PhoneNumber,
    Degree Degree, DateTime StartDate) : UserOutputDto(Id, Username, Name, NationalId, PhoneNumber)
{
}
