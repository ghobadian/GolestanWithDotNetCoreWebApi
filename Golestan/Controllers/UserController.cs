using System.Reflection.Metadata;
using DataLayer.Enums;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.Users;
using Golestan.Services;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

public class UserController {
    public readonly UserService service;

    
    [HttpGet]
    public IEnumerable<User> List(/*auth*//*request_param*/ /*int page, *//*request_param*/ /*int number*/) {
        return service.List(/*page, number*/);
    }

    
    [HttpPost]
    public User Create(string username, string password, string name, string phone, string nationalId) {
        return service.Create(username, password, name, phone, nationalId);
    }

    
    [HttpGet("{id:int}")]
    public User Read(int id/*auth*/) {
        return service.Read(id);
    }

    
    [HttpPut("{username}")]
    public User Update(string? name, string? newUsername, string? newPassword, string? phone, string username) {
        return service.Update(name, newUsername, newPassword, phone, username);
    }

    
    [HttpDelete("{id:int}")]
    //auth
    public void Delete(int id/*auth*/) {
        service.Delete(id);
    }

    
    [HttpPost("{id:int}")]
    public User ModifyRole(int id, [FromBody] RoleDto roleDto
                             /*auth*/) {
        return service.ModifyRole(id, roleDto);
    }

    
    [HttpPost]
    public string Login(/*request_param*/ string username,
                        /*request_param*/ string password) {
        return service.Login(username);
    }

    
    [HttpPost]
    public void logout(/*auth*/) {
        //service.logout(token);
    }
}
