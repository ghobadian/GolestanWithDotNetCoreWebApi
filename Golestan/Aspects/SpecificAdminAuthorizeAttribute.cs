using DataLayer.Enums;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Golestan.Aspects;

public class SpecificAdminAuthorizeAttribute : ServiceFilterAttribute
{
    public SpecificAdminAuthorizeAttribute() : base(typeof(ISpecificAdminAuthorize))
    {

    }

    public interface ISpecificAdminAuthorize : IActionFilter
    {
        
    }

    public class SpecificAdminAuthorize : IActionFilter
    {
        private readonly IAdminRepository adminRepository;

        public SpecificAdminAuthorize(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var tokenValue = context.ActionArguments["token"].ToString();
            var token = TokenRepository.GetById(tokenValue);
            var id = (int)context.ActionArguments["id"];
            if (adminRepository.FindByUsername(token.UserName).Id != id) throw new UnAuthorizedException();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
