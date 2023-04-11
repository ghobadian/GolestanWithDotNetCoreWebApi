using DataLayer.Enums;
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
        private readonly IStudentRepository studentRepository;

        public StudentAuthorize(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var token = TokenValidator.Validate(context.ActionArguments["token"]?.ToString(), Role.STUDENT, Role.INSTRUCTOR, Role.ADMIN);
            if (!studentRepository.FindByUsername(token.UserName).Active) throw new InactiveUserException();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
