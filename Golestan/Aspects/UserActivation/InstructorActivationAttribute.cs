using DataLayer.Enums;
using DataLayer.Models.Entities.Users;
using DataLayer.Repositories;
using Golestan.Business.Exceptions;
using Golestan.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Golestan.Aspects.UserActivation;

public class InstructorActivationAttribute : ServiceFilterAttribute
{
    public InstructorActivationAttribute() : base(typeof(IInstructorActivation))
    {

    }
    public interface IInstructorActivation : IActionFilter
    {

    }
    public class InstructorActivation : IInstructorActivation
    {

        private readonly IUserRepository<Instructor> instructorRepository;

        public InstructorActivation(IUserRepository<Instructor> instructorRepository)
        {
            this.instructorRepository = instructorRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var id = (int)context.ActionArguments["instructorId"];
            if (!instructorRepository.ExistsById(id))
                throw new Exception("Instructor with this id does not exist");
            if (instructorRepository.GetById(id).Active) throw new Exception("user is already active");
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
