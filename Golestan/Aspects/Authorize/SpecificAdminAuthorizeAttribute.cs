using DataLayer.Models.Entities.Users;
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
        private readonly IUserRepository<Admin> adminRepository;

        public SpecificAdminAuthorize(IUserRepository<Admin> adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        [AdminAuthorize]
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var rawToken = context.ActionArguments["token"].ToString();
            var token = TokenRepository.GetById(rawToken);
            var id = (int)context.ActionArguments["id"];
            if (adminRepository.FindByUsername(token.Username).Id != id) throw new UnAuthorizedException();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
