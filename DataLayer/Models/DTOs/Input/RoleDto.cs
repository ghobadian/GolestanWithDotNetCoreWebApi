using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Models.DTOs.Input
{
    public class RoleDto
    {
        public Role Role { get; init; }
        public Degree? Degree { get; init; }
        public Rank? Rank { get; init; }

    }
}
