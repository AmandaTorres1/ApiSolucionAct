using Dao_library;
using Entity_library;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly ILogger<TrainerController> _logger;
        private readonly TrainerDao _trainerDAO;

        public TrainerController(ILogger<TrainerController> logger, TrainerDao trainerDAO)
        {
            _logger = logger;
            _trainerDAO = trainerDAO;
        }

        [HttpGet]
        public List<Trainer> GetTrainers()
        {
            return _trainerDAO.GetAllTrainers();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var trainer = _trainerDAO.ReadTrainerById(id);
            if (trainer == null)
            {
                return NotFound();
            }
            return Ok(trainer);
        }

        [HttpPost]
        public ActionResult CreateTrainer(Trainer trainer)
        {
            if (trainer.Name == null)
            {
                return BadRequest("Name is required.");
            }

            Trainer createdTrainer = _trainerDAO.CreateTrainer(trainer);
            return Created($"/trainer/{createdTrainer.Id}", createdTrainer);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTrainer(long id, Trainer trainer)
        {
            Trainer? existingTrainer = _trainerDAO.ReadTrainerById(id);
            if (existingTrainer == null)
            {
                return NotFound();
            }

            trainer.Id = id;
            _trainerDAO.UpdateTrainer(trainer);

            return Ok(trainer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrainer(long id)
        {
            bool deleted = _trainerDAO.DeleteTrainerById(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
