using DataLayer.Enums;

namespace DataLayer.Models.DTOs.Output;

public record InstructorOutputDto(int Id, string Username, string Name, string NationalId, string PhoneNumber,
    Rank Rank) : UserOutputDto(Id, Username, Name, NationalId, PhoneNumber);

