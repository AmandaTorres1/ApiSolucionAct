using Dao_library;
using Entity_library;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly CourseDao _courseDAO;

        public CourseController(ILogger<CourseController> logger, CourseDao courseDAO)
        {
            _logger = logger;
            _courseDAO = courseDAO;
        }

        [HttpGet]
        public List<Course> GetCourses()
        {
            return _courseDAO.GetAllCourses();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var course = _courseDAO.ReadCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            if (course.Name == null)
            {
                return BadRequest("Name is required.");
            }

            Course createdCourse = _courseDAO.CreateCourse(course);
            return Created($"/course/{createdCourse.Id}", createdCourse);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCourse(long id, Course course)
        {
            Course? existingCourse = _courseDAO.ReadCourseById(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            course.Id = id;
            _courseDAO.UpdateCourse(course);

            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(long id)
        {
            bool deleted = _courseDAO.DeleteCourseById(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
