using DataLayer.Services;
using Golestan.Aspects.ExceptionHandling;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers;

[ApiController]
[Route("/[controller]/[action]")]
[HandleExceptions]
public class UserController : ControllerBase
{
    [HttpPost]
    public void Logout([FromHeader] string token) => TokenRepository.Delete(token);
}