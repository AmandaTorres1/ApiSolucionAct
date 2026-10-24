using Dao_library;
using Entity_library;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly PlayerDao _playerDAO;

        public PlayerController(ILogger<PlayerController> logger, PlayerDao playerDAO)
        {
            _logger = logger;
            _playerDAO = playerDAO;
        }

        [HttpGet]
        public List<Player> GetPlayers()
        {
            return _playerDAO.GetAllPlayers();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var player = _playerDAO.ReadPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        public ActionResult CreatePlayer(Player player)
        {
            if (player.Name == null)
            {
                return BadRequest("Name is required.");
            }

            Player createdPlayer = _playerDAO.CreatePlayer(player);
            return Created($"/player/{createdPlayer.Id}", createdPlayer);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePlayer(long id, Player player)
        {
            Player? existingPlayer = _playerDAO.ReadPlayerById(id);
            if (existingPlayer == null)
            {
                return NotFound();
            }

            player.Id = id;
            _playerDAO.UpdatePlayer(player);

            return Ok(player);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(long id)
        {
            bool deleted = _playerDAO.DeletePlayerById(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
