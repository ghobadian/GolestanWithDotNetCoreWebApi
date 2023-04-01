using DataLayer.Contexts;
using DataLayer.Models;
using DataLayer.Models.Users;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Services;
using Golestan.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
        builder.Services.AddSingleton<DbContext, LoliBase>();
        builder.Services.AddSingleton<ICourseService, CourseService>();
    }

    private static void RepositoryDependencyInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ICourseRepository, CourseRepository>();
        builder.Services.AddSingleton<ICourseSectionRepository, CourseSectionRepository>();
        builder.Services.AddSingleton<ICourseSectionRegistrationRepository, CourseSectionRegistrationRepository>();
        builder.Services.AddSingleton<IInstructorRepository, InstructorRepository>();
        builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
        builder.Services.AddSingleton<ITermRepository, TermRepository>();
        builder.Services.AddSingleton<IUserRepository, UserRepository>();
    }
}
}