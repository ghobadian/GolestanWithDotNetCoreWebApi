using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Entities;

public abstract class Crud
{
    [Key]
    public int Id { get; set; }
}