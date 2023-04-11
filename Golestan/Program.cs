using System.Text;
using AutoMapper;
using DataLayer.Contexts;
using DataLayer.Models;
using DataLayer.Models.Users;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Aspects.Authorize;
using Golestan.Aspects.ExceptionHandling;
using Golestan.Services;
using Golestan.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Golestan
{
    public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<LoliBase>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("Lolita")));
        DependencyInjection(builder);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();


        app.UseAuthorization();

        app.MapControllers();

        app.UseRouting();

        app.Run();
    }


    private static void DependencyInjection(WebApplicationBuilder builder) 
    {
        RepositoryDependencyInjection(builder);
        ServiceDependencyInjection(builder);
        AuthorizationDependencyInjection(builder);
        ExceptionHandlingInjection(builder);
    }

    private static void ExceptionHandlingInjection(WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<HandleExceptionsAttribute.IHandleExceptions, HandleExceptionsAttribute.HandleExceptions>();
    }

    private static void AuthorizationDependencyInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<AdminAuthorizeAttribute.IAdminAuthorize, AdminAuthorizeAttribute.AdminAuthorize>();
        builder.Services.AddScoped<SpecificAdminAuthorizeAttribute.ISpecificAdminAuthorize, SpecificAdminAuthorizeAttribute.SpecificAdminAuthorize>();
        builder.Services.AddScoped<InstructorAuthorizeAttribute.IInstructorAuthorize, InstructorAuthorizeAttribute.InstructorAuthorize>();
        builder.Services.AddScoped<SpecificInstructorAuthorizeAttribute.ISpecificInstructorAuthorize, SpecificInstructorAuthorizeAttribute.SpecificInstructorAuthorize>();
        builder.Services.AddScoped<StudentAuthorizeAttribute.IStudentAuthorize, StudentAuthorizeAttribute.StudentAuthorize>();
    }

    private static void ServiceDependencyInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAdminService, AdminService>();
        builder.Services.AddScoped<ICourseSectionService, CourseSectionService>();
        builder.Services.AddScoped<ICourseService, CourseService>();
        builder.Services.AddScoped<IInstructorService, InstructorService>();
        builder.Services.AddScoped<IStudentService, StudentService>();
        builder.Services.AddScoped<ITermService, TermService>();
        builder.Services.AddScoped<IUserService, UserService>();
    }

    private static void RepositoryDependencyInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAdminRepository, AdminRepository>();
        builder.Services.AddScoped<ICourseRepository, CourseRepository>();
        builder.Services.AddScoped<ICourseSectionRepository, CourseSectionRepository>();
        builder.Services.AddScoped<ICourseSectionRegistrationRepository, CourseSectionRegistrationRepository>();
        builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddScoped<ITermRepository, TermRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}
}