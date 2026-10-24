using Dao_library;
using Entity_library;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly TeamDao _teamDAO;

        public TeamController(ILogger<TeamController> logger, TeamDao teamDAO)
        {
            _logger = logger;
            _teamDAO = teamDAO;
        }

        [HttpGet]
        public List<Team> GetTeams()
        {
            return _teamDAO.GetAllTeams();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var team = _teamDAO.ReadTeamById(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPost]
        public ActionResult CreateTeam(Team team)
        {
            if (team.Name == null || team.Categoty == null)
            {
                return BadRequest("Name and Category are required.");
            }

            Team createdTeam = _teamDAO.CreateTeam(team);
            return Created($"/team/{createdTeam.Id}", createdTeam);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTeam(long id, Team team)
        {
            Team? existingTeam = _teamDAO.ReadTeamById(id);
            if (existingTeam == null)
            {
                return NotFound();
            }

            team.Id = id;
            _teamDAO.UpdateTeam(team);

            return Ok(team);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(long id)
        {
            bool deleted = _teamDAO.DeleteTeamById(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
