using DataLayer.Enums;
using DataLayer.Models;
using DataLayer.Models.Entities.Users;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Golestan.Aspects.Authorize;

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
        private readonly IUserRepository<Instructor> instructorRepository;

        public SpecificInstructorAuthorize(IUserRepository<Instructor> instructorRepository) => this.instructorRepository = instructorRepository;
        
        [InstructorAuthorize]
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var rawToken = context.ActionArguments["token"].ToString();
            var token = TokenRepository.GetById(rawToken);
            if (token.Role == Role.ADMIN) return;
            var instructor = instructorRepository.FindByUsername(token.Username);
            if (context.ActionArguments.ContainsKey("id"))
            {
                var id = (int)context.ActionArguments["id"];
                if (instructor.Id != id) throw new UnAuthorizedException();
            }
            if (context.ActionArguments.ContainsKey("courseSectionId"))
            {
                var courseSectionId = (int)context.ActionArguments["courseSectionId"];
                if (instructor.CourseSections.Select(cs => cs.Id).All(id => id != courseSectionId)) throw new UnAuthorizedException();
            }

            if (context.ActionArguments.ContainsKey("courseId"))
            {
                var courseId = (int) context.ActionArguments["courseId"];
                if (instructor.CourseSections.Select(cs => cs.Course).All(course => course.Id != courseId))
                    throw new UnAuthorizedException();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
