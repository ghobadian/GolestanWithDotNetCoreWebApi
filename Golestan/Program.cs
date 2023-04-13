using DataLayer.Contexts;
using DataLayer.Enums;
using DataLayer.Models.DTOs;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Aspects.Authorize;
using Golestan.Aspects.ExceptionHandling;
using Golestan.Services;
using Golestan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Golestan;

public class Program
{
    public static WebApplicationBuilder builder;
    public static void Main(string[] args)
    {

        builder = WebApplication.CreateBuilder(args);

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
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //c.RoutePrefix = "";
            });
            TokenRepository.Insert(new Token("token", DateTime.MaxValue, Role.ADMIN, "admin"));
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
