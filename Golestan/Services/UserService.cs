using DataLayer.Enums;
using Microsoft.CodeAnalysis;
using System.Runtime.InteropServices;
using System;
using System.Text.RegularExpressions;
using DataLayer.Repositories;
using Golestan.Services.Interfaces;
using Golestan.Utils;
using DataLayer.Models.DTOs.Input;
using Golestan.Business.Exceptions;
using DataLayer.Models.Entities.Users;

namespace Golestan.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public void CreateUserAspects(User user, UserInputDto newUser)
    {
        UpdateUsername(user, newUser.Username);
        UpdatePassword(user, newUser.Password);
        UpdateName(user, newUser.Name);
        UpdatePhoneNumber(user, newUser.Phone);
        UpdateNationalId(user, newUser.NationalId);
    }

    private void UpdatePhoneNumber(User user, string? phone)
    {
        if (phone == null || userRepository.ExistsByPhone(phone)) throw new Exception("invalid phone number");
        if (!Regex.IsMatch(phone, "^0?9\\d{9}$")) throw new InvalidPhoneNumberException();
        user.PhoneNumber = phone;
    }

    private static void UpdatePassword(User user, string? newPassword)
    {
        if (newPassword == null) throw new Exception("password required");
        if (!Regex.IsMatch(newPassword, "(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}"))
            throw new WeakPasswordException();
        user.Password = PasswordEncoder.Encode(newPassword);
    }

    private void UpdateUsername(User user, string? newUsername)
    {
        if (newUsername == null || userRepository.ExistsByUsername(user.UserName)) throw new Exception("Try another username");
        user.UserName = newUsername;
    }

    private static void UpdateName(User user, string? name)
    {
        if (name == null) throw new Exception("name is null");
        user.Name = name;
    }

    private void UpdateNationalId(User user, string? nationalId)
    {
        if (nationalId == null || userRepository.ExistsByNationalId(nationalId))
            throw new Exception("invalid national id");
        if (!Regex.IsMatch(nationalId, "^\\d{10}$")) throw new InvalidEmailException();
        user.NationalId = nationalId;
    }

}

