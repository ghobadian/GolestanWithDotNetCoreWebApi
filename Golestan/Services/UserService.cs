using DataLayer.Enums;
using DataLayer.Models.Users;
using Microsoft.CodeAnalysis;
using System.Runtime.InteropServices;
using System;
using DataLayer.Repositories;
using Golestan.Services.Interfaces;
using Golestan.Utils;
using DataLayer.Models.DTOs.Input;

namespace Golestan.Services;

public class UserService : IUserService
{
    private readonly IInstructorService instructorService;
    private readonly IStudentService studentService;
    private readonly IUserRepository userRepository;
    private readonly IStudentRepository studentRepository;
    private readonly IInstructorRepository instructorRepository;

    public UserService(IInstructorService instructorService, 
        IStudentService studentService, 
        IUserRepository userRepository, 
        IStudentRepository studentRepository, 
        IInstructorRepository instructorRepository)
    {
        this.instructorService = instructorService;
        this.studentService = studentService;
        this.userRepository = userRepository;
        this.studentRepository = studentRepository;
        this.instructorRepository = instructorRepository;
    }

    //private readonly PasswordEncoder passwordEncoder;

    public IEnumerable<User> List(/*int page, int number*/)
    {
        return userRepository.GetAll();
    }

    public User Create(string username, string password, string name, string phone, string nationalId)
    {
        var user = new User
        {
            Username = username,
            Password = PasswordEncoder.Encode(password),//todo encode passwords
            Name = name,
            Phone = phone,
            NationalId = nationalId,
            Active = false,
            Admin = false
        };
        
        //log.info("User with username " + username + " created");
        var insertedUser = userRepository.Insert(user);
        userRepository.Save();
        return insertedUser;
    }

    public User Read(int id) => userRepository.GetById(id);

    public User Update(string? name, string? newUsername, string? newPassword, string? newPhone, string? username)
    {
        User user = userRepository.FindByUsername(username);
        UpdateName(name, user);
        UpdateUsername(newUsername, username, user);
        UpdatePassword(newPassword, user);
        UpdatePhoneNumber(newPhone, user);
        userRepository.Update(user);
        userRepository.Save();
        return user;
    }

    private void UpdatePhoneNumber(string? phone, User user)
    {
        if (phone == null || userRepository.ExistsByPhone(phone)) return;
        user.Phone = phone;
    }

    private void UpdatePassword(string? newPassword, User user)
    {
        if (newPassword == null) return;
        user.Password = PasswordEncoder.Encode(newPassword);
    }

    private void UpdateUsername(string? newUsername, string? username, User user)
    {
        
        if (newUsername == null || username == null || userRepository.ExistsByUsername(username)) return;
        user.Username = username;
    }

    private static void UpdateName(string? name, User user)
    {
        if (name == null) return;
        user.Name = name;
    }

    public void Delete(int id)
    {
        //User user = repo.findUser(id);
        //DeleteInstructorOfUser(user);
        //DeleteStudentOfUser(user);
        userRepository.Delete(id);
        //repo.DeleteUser(user);
        //log.info("User with id " + id + " Deleted");
        userRepository.Save();
    }

    //private void DeleteStudentOfUser(User user)
    //{
    //    if (user.getInstructor() != null)
    //    {
    //        int instructorId = user.getInstructor().getId();
    //        user.setInstructor(null);
    //        instructorService.Delete(instructorId);
    //    }
    //}

    //private void DeleteInstructorOfUser(User user)
    //{
    //    if (user.getStudent() != null)
    //    {
    //        int studentId = user.getStudent().getId();
    //        user.setStudent(null);
    //        studentService.Delete(studentId);
    //    }
    //}

    public User ModifyRole(int id, RoleDto role)
    {
        var foundUser = userRepository.GetById(id);
        foundUser.Active = true;
        return role.Role switch
        {
            Role.STUDENT => AddRoleStudent(role.Degree, foundUser),
            Role.INSTRUCTOR => AddRoleInstructor(role.Rank, foundUser)
        };
    }

    private User AddRoleInstructor(Rank? rank, User user)
    {
        if (rank == null) throw new Exception("rank can not be null");
        var instructor = new Instructor { Rank = rank.Value, User = user };
        user.Instructor = instructor;
        instructorRepository.Insert(instructor);
        instructorRepository.Save();
        userRepository.Update(user);
        instructorRepository.Save();
        userRepository.Save();
        return user;
    }

    private User AddRoleStudent(Degree? degree, User user)
    {
        if (degree == null) throw new Exception("degree can't be null");
        var student = new Student { Degree = degree.Value, StartDate = new DateOnly(), User = user};
        user.Student = student;
        studentRepository.Insert(student);
        userRepository.Update(user);
        studentRepository.Save();
        userRepository.Save();
        return user;
    }

    public string Login(string username)
    {
        //string token = UUID.randomUUID().tostring();
        //return repo.saveToken(username, token);
        return null;
    }

    public void Logout(string username)
    {
        //repo.DeleteTokenByUsername(username);
    }
}

