using DataLayer.Enums;
using DataLayer.Models.Entities.Users;
using DataLayer.Repositories;
using Golestan.Business.Exceptions;
using Golestan.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Golestan.Aspects.UserActivation;

public class AdminActivationAttribute : ServiceFilterAttribute
{
    public AdminActivationAttribute() : base(typeof(IAdminActivation))
    {

    }
    public interface IAdminActivation : IActionFilter
    {

    }
    public class AdminActivation : IAdminActivation
    {

        private readonly IUserRepository<Admin> adminRepository;

        public AdminActivation(IUserRepository<Admin> adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var id = (int)context.ActionArguments["adminId"];
            if (!adminRepository.ExistsById(id))
                throw new Exception("Admin with this id does not exist");
            if (adminRepository.GetById(id).Active) throw new Exception("user is already active");
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
