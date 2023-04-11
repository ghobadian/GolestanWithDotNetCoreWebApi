using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Aspects.Authorize;

public class SpecificAdminAuthorizeAttribute : ServiceFilterAttribute
{
    public SpecificAdminAuthorizeAttribute() : base(typeof(ISpecificAdminAuthorize))
    {

    }

    public interface ISpecificAdminAuthorize : IActionFilter
    {

    }

    public class SpecificAdminAuthorize : ISpecificAdminAuthorize
    {
        private readonly IAdminRepository adminRepository;

        public SpecificAdminAuthorize(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var rawToken = context.ActionArguments["token"].ToString();
            var token = TokenRepository.GetById(rawToken);
            var id = (int)context.ActionArguments["id"];
            if (adminRepository.FindByUsername(token.UserName).Id != id) throw new UnAuthorizedException();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
