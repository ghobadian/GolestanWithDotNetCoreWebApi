﻿using DataLayer.Enums;
using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Entities.Users;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Golestan.Services.Interfaces;
using Golestan.Utils;
using Microsoft.VisualBasic;

namespace Golestan.Services;
public class AdminService : IAdminService
{
    private readonly IUserRepository<Instructor> instructorRepository;
    private readonly IUserRepository<Admin> adminRepository;
    private readonly IUserRepository<Student> studentRepository;
    private readonly IUserService userService;
    private readonly ILogger<AdminService> logger;


    public AdminService(IUserRepository<Admin> adminRepository,
        IUserService userService, 
        IUserRepository<Instructor> instructorRepository, 
        IUserRepository<Student> studentRepository, ILogger<AdminService> logger)//todo
    {
        this.adminRepository = adminRepository;
        this.userService = userService;
        this.instructorRepository = instructorRepository;
        this.studentRepository = studentRepository;
        this.logger = logger;
    }

    public IEnumerable<AdminOutputDto> List(int pageNumber, int pageSize) => adminRepository.GetAll(pageNumber, pageSize).Select(admin => admin.OutputDto());

    public AdminOutputDto Create(AdminInputDto newAdmin)    
    {
        var admin = new Admin();
        userService.CreateUserAspects(admin, newAdmin);
        logger.LogInformation("User with username " + newAdmin.Username + " created");
        var insertedAdmin = adminRepository.Insert(admin);//todo change to bool and check with if clause
        adminRepository.Save();
        return insertedAdmin.OutputDto();
    }

    public AdminOutputDto Read(int id) => adminRepository.GetById(id).OutputDto();

    public AdminOutputDto Update(int id, AdminInputDto newAdmin)
    {
        var admin = adminRepository.GetById(id);//todo test this shit fast
        userService.CreateUserAspects(admin, newAdmin);
        adminRepository.Update(admin);
        adminRepository.Save();
        return admin.OutputDto();
    }

    public void Delete(int id)
    {
        adminRepository.Delete(id);
        adminRepository.Save();
    }

    public TokenOutputDto Login(string username, string password)
    {
        CheckAuthority(username, password);
        var token = TokenGenerator.GenerateToken(Role.ADMIN, username);
        TokenRepository.Insert(token);
        return token.OutputDto();
    }

    private void CheckAuthority(string username, string password)
    {
        if (!adminRepository.ExistsByUsername(username)) throw new UsernameOrPasswordInvalidException();
        var admin = adminRepository.FindByUsername(username);
        if (admin.Password != PasswordEncoder.Encode(password)) throw new UsernameOrPasswordInvalidException();
        if (TokenRepository.ExistsByUsername(username)) throw new ReLoginException();
    }

    public void ActivateAdmin(int adminId) => adminRepository.Activate(adminId);

    public void ActivateInstructor(int instructorId) => instructorRepository.Activate(instructorId);

    public void ActivateStudent(int studentId) => studentRepository.Activate(studentId);
}
