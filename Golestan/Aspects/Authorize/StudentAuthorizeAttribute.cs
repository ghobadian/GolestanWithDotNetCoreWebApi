using DataLayer.Enums;
using DataLayer.Models.Entities.Users;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Golestan.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Golestan.Aspects.Authorize;

public class StudentAuthorizeAttribute : ServiceFilterAttribute
{
    public StudentAuthorizeAttribute() : base(typeof(IStudentAuthorize))
    {

    }

    public interface IStudentAuthorize : IActionFilter
    {

    }
    public class StudentAuthorize : IStudentAuthorize
    {
        private readonly IUserRepository<Student> studentRepository;

        public StudentAuthorize(IUserRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var token = TokenValidator.Validate(context.ActionArguments["token"]?.ToString(), Role.STUDENT, Role.INSTRUCTOR, Role.ADMIN);
            if (token.Role == Role.ADMIN || token.Role == Role.INSTRUCTOR) return;
            if (!studentRepository.FindByUsername(token.Username).Active) throw new InactiveUserException();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
