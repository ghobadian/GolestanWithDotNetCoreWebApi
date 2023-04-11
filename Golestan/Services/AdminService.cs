using DataLayer.Enums;
using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Models.Users;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Golestan.Services.Interfaces;
using Golestan.Utils;
using Microsoft.VisualBasic;

namespace Golestan.Services;
public class AdminService : IAdminService
{
    private readonly IAdminRepository adminRepository;
    private readonly IInstructorRepository instructorRepository;
    private readonly IStudentRepository studentRepository;
    private readonly IUserService userService;
    private readonly ILogger<AdminService> logger;


    public AdminService(IAdminRepository adminRepository,
        IUserService userService, 
        IInstructorRepository instructorRepository, 
        IStudentRepository studentRepository, ILogger<AdminService> logger)//todo
    {
        this.adminRepository = adminRepository;
        this.userService = userService;
        this.instructorRepository = instructorRepository;
        this.studentRepository = studentRepository;
        this.logger = logger;
    }

    public IEnumerable<AdminOutputDto> List(/*int page, int number*/)
    {
        return adminRepository.GetAll().Select(admin => admin.OutputDto());
    }

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

    public void ActivateAdmin(int adminId)
    {
        adminRepository.Update(new Admin() { Id = adminId, Active = true });
    }

    public void ActivateInstructor(int instructorId)
    {
        instructorRepository.Update(new Instructor() { Id = instructorId, Active = true });
    }

    public void ActivateStudent(int studentId)
    {
        studentRepository.Update(new Student() { Id = studentId, Active = true });
    }

}
