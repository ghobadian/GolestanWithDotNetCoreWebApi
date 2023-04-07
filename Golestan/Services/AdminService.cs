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
    private readonly IUserService userService;

    public AdminService(IAdminRepository adminRepository, IUserService userService)
    {
        this.adminRepository = adminRepository;
        this.userService = userService;
    }

    public IEnumerable<Admin> List(/*int page, int number*/)
    {
        return adminRepository.GetAll();
    }

    public Admin Create(AdminInputDto newAdmin)    
    {
        var admin = new Admin();
        userService.CreateUserAspects(admin, newAdmin);
        //log.info("User with username " + username + " created");
        var insertedAdmin = adminRepository.Insert(admin);
        adminRepository.Save();
        return insertedAdmin;
    }

    public Admin Read(int id) => adminRepository.GetById(id);

    public Admin Update(int id, AdminInputDto newAdmin)
    {
        var admin = adminRepository.GetById(id);//todo test this shit fast
        userService.CreateUserAspects(admin, newAdmin);
        adminRepository.Update(admin);
        adminRepository.Save();
        return admin;
    }

    public void Delete(int id)
    {
        adminRepository.Delete(id);
        adminRepository.Save();
    }

    public TokenOutputDto Login(string username, string password)
    {
        if(username == null || password == null || !adminRepository.ExistsByUsername(username)) throw new UsernameOrPasswordInvalidException();
        var admin = adminRepository.FindByUsername(username);
        if (admin.Password != PasswordEncoder.Encode(password)) throw new UsernameOrPasswordInvalidException();
        DateTime validUntil = new DateTime() + TimeSpan.FromMinutes(30);
        string tokenValue = TokenGenerator.GenerateToken();
        var token = new Token { Role = Role.ADMIN, UserName = username, ValidUntil = validUntil, Value = tokenValue };
        TokenRepository.Insert(token);
        return new TokenOutputDto() { Token = "todo", ValidUntil = validUntil };
        //todo implement valid until and token generation
    }


    public void Activate(string username)//todo find usage
    {
        var admin = adminRepository.FindByUsername(username);
        admin.Active = true;

    }
}
