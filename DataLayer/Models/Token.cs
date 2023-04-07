using DataLayer.Enums;

namespace DataLayer.Models;

public class Token
{
    public string Value { get; set; }
    public DateTime ValidUntil { get; set; }
    public Role Role { get; set; }
    public string UserName { get; set; }
}

