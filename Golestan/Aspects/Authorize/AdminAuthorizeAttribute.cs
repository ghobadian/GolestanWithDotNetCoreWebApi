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

        private readonly IAdminRepository adminRepository;

        public AdminAuthorize(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var token = TokenValidator.Validate(context.ActionArguments["token"]?.ToString(), Role.ADMIN);
            if (!adminRepository.FindByUsername(token.Username).Active) throw new InactiveUserException();

        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
