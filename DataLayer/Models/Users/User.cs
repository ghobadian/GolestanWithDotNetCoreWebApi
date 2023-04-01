using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Xml;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        //todo must be unique
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        //unique
        //not updatable
        public string Phone { get; set; }
        
        [Required]
        //unique
        public string NationalId { get; set; }

        [Required]
        public bool Active { get; set; }
        //unique
        
        // public virtual Student? Student { get; set; }
        ////unique

        //public virtual Instructor? Instructor { get; set; }
    }
}