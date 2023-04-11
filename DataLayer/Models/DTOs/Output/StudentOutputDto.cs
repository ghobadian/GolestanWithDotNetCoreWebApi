using DataLayer.Enums;

namespace DataLayer.Models.DTOs.Output;

public record StudentOutputDto(int Id, string Username, string Name, string NationalId, string PhoneNumber,
    Degree Degree, DateOnly StartDate) : UserOutputDto(Id, Username, Name, NationalId, PhoneNumber);
