using Dao_library;
using Entity_library;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly ActivityDao _activityDAO;

        public ActivityController(ILogger<ActivityController> logger, ActivityDao activityDAO)
        {
            _logger = logger;
            _activityDAO = activityDAO;
        }

        [HttpGet]
        public List<Activity> GetActivities()
        {
            return _activityDAO.GetAllActivities();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var activity = _activityDAO.ReadActivityById(id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpPost]
        public ActionResult CreateActivity(Activity activity)
        {
            if (activity.Title == null)
            {
                return BadRequest("Title is required.");
            }

            Activity createdActivity = _activityDAO.CreateActivity(activity);
            return Created($"/activity/{createdActivity.Id}", createdActivity);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateActivity(long id, Activity activity)
        {
            Activity? existingActivity = _activityDAO.ReadActivityById(id);
            if (existingActivity == null)
            {
                return NotFound();
            }

            activity.Id = id;
            _activityDAO.UpdateActivity(activity);

            return Ok(activity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActivity(long id)
        {
            bool deleted = _activityDAO.DeleteActivityById(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
