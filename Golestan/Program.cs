using DataLayer.Contexts;
using DataLayer.Repositories;
using DataLayer.Services;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddDbContext<LoliBase>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Lolita")));
            DependencyInjections(builder);
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

            app.Run();
        }

        private static void DependencyInjections(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICourseSectionRepository, CourseSectionRepository>();
            builder.Services.AddScoped<ICourseSectionRegistrationRepository, CourseSectionRegistrationRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ITermRepository, TermRepository>();
        }
    }
}