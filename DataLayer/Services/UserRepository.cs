using DataLayer.Repositories;
using DataLayer.Models.Entities.Users;
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
    public class UserRepository : IUserRepositoryLight
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IStudentRepository _studentRepository;

        public UserRepository(IAdminRepository adminRepository, IInstructorRepository instructorRepository, IStudentRepository studentRepository)
        {
            _adminRepository = adminRepository;
            _instructorRepository = instructorRepository;
            _studentRepository = studentRepository;
        }

        public bool ExistsByPhone(string phone) =>
            _adminRepository.ExistsByPhone(phone) || _instructorRepository.ExistsByPhone(phone) ||
            _studentRepository.ExistsByPhone(phone);

        public bool ExistsByUsername(string username) =>
            _adminRepository.ExistsByUsername(username) || _instructorRepository.ExistsByUsername(username) ||
            _studentRepository.ExistsByUsername(username);

        public bool ExistsByNationalId(string nationalId) =>
            _adminRepository.ExistsByNationalId(nationalId) || _instructorRepository.ExistsByNationalId(nationalId) ||
            _studentRepository.ExistsByNationalId(nationalId);
    }
}
