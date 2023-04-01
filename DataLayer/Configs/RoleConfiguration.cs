﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configs;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }, 
            new IdentityRole { Name = "Student", NormalizedName = "STUDENT" },
            new IdentityRole {Name = "Instructor", NormalizedName = "INSTRUCTOR"}
            );
    }
}
