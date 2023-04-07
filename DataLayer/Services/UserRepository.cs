using DataLayer.Repositories;
using DataLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using System.Runtime.InteropServices;
using System.Numerics;

namespace DataLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly LoliBase db;
        public UserRepository(LoliBase db) => this.db = db;

        public bool ExistsByPhone(string phone) => 
            db.Admins.Any(admin => admin.PhoneNumber == phone) || 
            db.Instructors.Any(instructor => instructor.PhoneNumber == phone) ||
            db.Students.Any(student => student.PhoneNumber == phone);

        public bool ExistsByUsername(string UserName) => 
            db.Admins.Any(admin => admin.PhoneNumber == UserName) || 
            db.Instructors.Any(instructor => instructor.PhoneNumber == UserName) || 
            db.Students.Any(student => student.PhoneNumber == UserName);

        public bool ExistsByNationalId(string nationalId) =>
            db.Admins.Any(admin => admin.PhoneNumber == nationalId) ||
            db.Instructors.Any(instructor => instructor.PhoneNumber == nationalId) ||
            db.Students.Any(student => student.PhoneNumber == nationalId);
        
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
