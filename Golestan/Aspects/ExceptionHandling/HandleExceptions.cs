using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace Golestan.Aspects.ExceptionHandling;


public class HandleExceptionsAttribute : ServiceFilterAttribute
{

    public HandleExceptionsAttribute() : base(typeof(IHandleExceptions))
    {

    }

    public interface IHandleExceptions : IExceptionFilter
    {

    }
    public class HandleExceptions : IHandleExceptions
    {
        public void OnException(ExceptionContext context)
        {

            context.Result = new ContentResult
            {
                StatusCode = 400,
                Content = context.Exception.Message,//todo use regex to have dynamic status code
            };
        }
    }
}
