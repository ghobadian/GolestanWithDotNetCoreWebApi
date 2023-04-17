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
    public class AbstractUserRepository : IAbstractUserRepository
    {
        private readonly IUserRepository<Admin> _adminRepository;
        private readonly IUserRepository<Instructor> _instructorRepository;
        private readonly IUserRepository<Student> _studentRepository;

        public AbstractUserRepository(IUserRepository<Admin> adminRepository,
            IUserRepository<Instructor> instructorRepository, 
            IUserRepository<Student> studentRepository)
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
