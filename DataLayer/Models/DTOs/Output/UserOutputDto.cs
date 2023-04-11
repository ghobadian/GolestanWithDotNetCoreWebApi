namespace DataLayer.Models.DTOs.Output;

public record UserOutputDto(int Id,)
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string NationalId { get; set; }
    public string PhoneNumber { get; set; }
}