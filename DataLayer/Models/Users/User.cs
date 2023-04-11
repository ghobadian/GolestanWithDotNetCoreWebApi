using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Xml;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DataLayer.Models.Users
{
    public abstract class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        //todo unique
        public string NationalId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}