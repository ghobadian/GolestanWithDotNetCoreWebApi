using DataLayer.Enums;
using DataLayer.Models.Entities.Users;
using DataLayer.Repositories;
using Golestan.Business.Exceptions;
using Golestan.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Golestan.Aspects.UserActivation;

public class StudentActivationAttribute : ServiceFilterAttribute
{
    public StudentActivationAttribute() : base(typeof(IStudentActivation))
    {

    }
    public interface IStudentActivation : IActionFilter
    {

    }
    public class StudentActivation : IStudentActivation
    {

        private readonly IUserRepository<Student> studentRepository;

        public StudentActivation(IUserRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var id = (int)context.ActionArguments["studentId"];
            if (!studentRepository.ExistsById(id))
                throw new Exception("Student with this id does not exist");
            if (studentRepository.GetById(id).Active) throw new Exception("user is already active");
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
