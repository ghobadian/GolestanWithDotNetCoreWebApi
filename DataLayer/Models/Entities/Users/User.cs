using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Entities.Users
{
    public abstract class User : Crud
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string NationalId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}