using DataLayer.Enums;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Golestan.Aspects;

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
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var tokenValue = context.ActionArguments["token"].ToString();
            if (!TokenRepository.ExistsById(tokenValue)) throw new UnAuthorizedException();
            var token = TokenRepository.GetById(tokenValue);
            if (token.Role != Role.STUDENT && token.Role != Role.ADMIN) throw new UnAuthorizedException();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
