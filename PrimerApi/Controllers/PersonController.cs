using Dao_library;
using Entity_library;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly PersonDao _personDAO;

        public PersonController(ILogger<PersonController> logger, PersonDao personDAO)
        {
            _logger = logger;
            _personDAO = personDAO;
        }

        [HttpGet]
        public List<Person> GetPersons()
        {
            return _personDAO.GetAllPersons();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personDAO.ReadPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            if (person.Name == null)
            {
                return BadRequest("Name is required.");
            }

            Person createdPerson = _personDAO.CreatePerson(person);
            return Created($"/person/{createdPerson.Id}", createdPerson);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePerson(long id, Person person)
        {
            Person? existingPerson = _personDAO.ReadPersonById(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            person.Id = id;
            _personDAO.UpdatePerson(person);

            return Ok(person);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(long id)
        {
            bool deleted = _personDAO.DeletePersonById(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
