using DataLayer.Enums;
using DataLayer.Models.Users;
using Microsoft.CodeAnalysis;
using System.Runtime.InteropServices;
using System;
using System.Text.RegularExpressions;
using DataLayer.Repositories;
using Golestan.Services.Interfaces;
using Golestan.Utils;
using DataLayer.Models.DTOs.Input;
using Golestan.Business.Exceptions;

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
        if (phone == null || userRepository.ExistsByPhone(phone)) return;
        if (!Regex.IsMatch(phone, "^0?9\\d{9}$")) throw new InvalidPhoneNumberException();
        user.PhoneNumber = phone;
    }

    private static void UpdatePassword(User user, string? newPassword)
    {
        if (newPassword == null) return;
        if (!Regex.IsMatch(newPassword, "(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}"))
            throw new WeakPasswordException();
        user.Password = PasswordEncoder.Encode(newPassword);
    }

    private void UpdateUsername(User user, string? newUsername)
    {
        if (newUsername == null || userRepository.ExistsByUsername(user.UserName)) return;
        user.UserName = newUsername;
    }

    private static void UpdateName(User user, string? name)
    {
        if (name == null) return;
        user.Name = name;
    }

    private void UpdateNationalId(User user, string? nationalId)
    {
        if (nationalId == null || userRepository.ExistsByNationalId(nationalId)) return;
        if (!Regex.IsMatch(nationalId, "^\\d{10}$")) throw new InvalidEmailException();
        user.NationalId = nationalId;
    }

}

