using DataLayer.Enums;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Golestan.Aspects.Authorize;

public class SpecificStudentAuthorizeAttribute : ServiceFilterAttribute
{
    public SpecificStudentAuthorizeAttribute() : base(typeof(ISpecificStudentAuthorize))
    {

    }

    public interface ISpecificStudentAuthorize : IActionFilter
    {

    }

    public class SpecificStudentAuthorize : ISpecificStudentAuthorize
    {
        private readonly IStudentRepository studentRepository;

        public SpecificStudentAuthorize(IStudentRepository studentRepository) => this.studentRepository = studentRepository;

        [StudentAuthorize]
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var rawToken = context.ActionArguments["token"].ToString();
            var token = TokenRepository.GetById(rawToken);
            if (token.Role == Role.ADMIN || token.Role == Role.INSTRUCTOR) return;
            //todo check what else is inside the context
            var student = studentRepository.FindByUsername(token.Username);
            var id = (int)context.ActionArguments["id"];
            if (student.Id != id) throw new UnAuthorizedException();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
