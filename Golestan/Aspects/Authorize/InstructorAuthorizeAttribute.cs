using DataLayer.Contexts;
using DataLayer.Enums;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Golestan.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Golestan.Aspects.Authorize;

public class InstructorAuthorizeAttribute : ServiceFilterAttribute
{
    public InstructorAuthorizeAttribute() : base(typeof(IInstructorAuthorize))
    {

    }

    public interface IInstructorAuthorize : IActionFilter
    {

    }
    public class InstructorAuthorize : IInstructorAuthorize
    {
        private readonly IInstructorRepository instructorRepository;

        public InstructorAuthorize(IInstructorRepository instructorRepository)
        {
            this.instructorRepository = instructorRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var token = TokenValidator.Validate(context.ActionArguments["token"]?.ToString(), Role.INSTRUCTOR, Role.ADMIN);
            if (!instructorRepository.FindByUsername(token.UserName).Active) throw new InactiveUserException();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
