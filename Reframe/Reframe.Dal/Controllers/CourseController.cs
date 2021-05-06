using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reframe.Dal.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reframe.Dal.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCourses()
        {
            try
            {
                var result = await _courseService.GetCourses();
                return Ok(result);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("Hiba történt: " + e.Message);
            }

        }
    
    }
}
