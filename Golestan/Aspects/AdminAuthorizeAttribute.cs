using DataLayer.Contexts;
using DataLayer.Enums;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Golestan.Aspects;

public class AdminAuthorizeAttribute : ServiceFilterAttribute
{
    public AdminAuthorizeAttribute() : base(typeof(IAdminAuthorize))
    {

    }
    public interface IAdminAuthorize : IActionFilter
    {
        
    }
    public class AdminAuthorize : IAdminAuthorize
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var tokenValue = context.ActionArguments["token"].ToString();
            if (!TokenRepository.ExistsById(tokenValue)) throw new UnAuthorizedException();
            var token = TokenRepository.GetById(tokenValue);
            if (token.Role != Role.ADMIN) throw new UnAuthorizedException();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
