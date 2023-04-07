using DataLayer.Contexts;
using DataLayer.Enums;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Golestan.Aspects;

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
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var tokenValue = context.ActionArguments["token"].ToString();
            if (!TokenRepository.ExistsById(tokenValue)) throw new UnAuthorizedException();
            var token = TokenRepository.GetById(tokenValue);
            if (token.Role != Role.INSTRUCTOR && token.Role != Role.ADMIN) throw new UnAuthorizedException();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
