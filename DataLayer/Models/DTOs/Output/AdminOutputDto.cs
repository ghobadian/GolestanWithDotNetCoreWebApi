namespace DataLayer.Models.DTOs.Output;

public record AdminOutputDto(int Id, string Username, string Name, string NationalId, string PhoneNumber) : 
    UserOutputDto(Id, Username, Name, NationalId, PhoneNumber);