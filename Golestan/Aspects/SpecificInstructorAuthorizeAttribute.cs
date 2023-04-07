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

public class SpecificInstructorAuthorizeAttribute : ServiceFilterAttribute
{
    public SpecificInstructorAuthorizeAttribute() : base(typeof(ISpecificInstructorAuthorize))
    {

    }

    public interface ISpecificInstructorAuthorize : IActionFilter
    {
        
    }

    public class SpecificInstructorAuthorize : ISpecificInstructorAuthorize
    {
        private readonly IInstructorRepository instructorRepository;

        public SpecificInstructorAuthorize(IInstructorRepository instructorRepository) => this.instructorRepository = instructorRepository;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var tokenValue = context.ActionArguments["token"].ToString();
            var token = TokenRepository.GetById(tokenValue);
            if (token.Role == Role.ADMIN) return;
            //todo check what else is inside the context
            var instructor = instructorRepository.FindByUsername(token.UserName);
            if (context.ActionArguments.ContainsKey("id"))
            {
                var id = (int)context.ActionArguments["id"];
                if (instructor.Id != id) throw new UnAuthorizedException();
            }
            else if (context.ActionArguments.ContainsKey("courseSectionId"))
            {
                var courseSectionId = (int)context.ActionArguments["courseSectionId"];
                if (instructor.CourseSections.Select(cs => cs.Id).All(id => id != courseSectionId)) throw new UnAuthorizedException();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
