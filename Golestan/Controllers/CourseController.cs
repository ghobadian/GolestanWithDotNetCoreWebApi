using DataLayer.Models;
using DataLayer.Models.Users;
using Golestan.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Golestan.Controllers
{
    [ApiController]
	[Route("[controller]")]
    public class CourseController : ControllerBase
	{

		public readonly ICourseService cs;
		public CourseController(ICourseService cs)
		{
			this.cs = cs;
		}

		//public readonly CourseSecurityService securityService;



		//public List<Course> List(int page, int number)
		//{
		//	return cs.List(page, number);
		//}

		[HttpGet("List")]
		public IEnumerable<Course> Get()
		{
			return cs.List();
		}


		[HttpPost("Create")]
		public Course create(int units, string title)
		{
			return cs.Create(units, title);
		}

		[HttpGet("Read")]
		public Course Read(int id)
		{
			return cs.Read(id);
		}

		[HttpPut("Update")]
		public Course Update(int id,
							  /*(required = false)*/ string title,
							  /*(required = false)*/ int units)
		{

			return cs.Update(id, title, units);
		}


		[HttpDelete("id")]
		public void Delete(int id)
		{
			cs.Delete(id);
		}
	}

}
