using Dao_library;
using Entity_library;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly StudentDAO _studentDAO;

        public StudentController(ILogger<StudentController> logger, StudentDAO studentDAO)
        {
            _logger = logger;
            _studentDAO = studentDAO;
        }

        [HttpGet]
        public List<Student> GetStudents()
        {
            return _studentDAO.GetAllStudents();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var student = _studentDAO.ReadStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            if (student.Name == null || student.File == null)
            {
                return BadRequest("Name and File are required.");
            }

            Student createdStudent = _studentDAO.CreateStudent(student);
            return Created($"/student/{createdStudent.Id}", createdStudent);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(long id, Student student)
        {
            Student? existingStudent = _studentDAO.ReadStudentById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            student.Id = id;
            _studentDAO.UpdateStudent(student);

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(long id)
        {
            bool deleted = _studentDAO.DeleteStudentById(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
