using Entity_library;

namespace Dao_library
{
    public class PlayerDao
    {
        public Player CreatePlayer(Player player)
        {
            player.Id = MockDatabase.Players.Count + 1;
            MockDatabase.Players.Add(player);
            return player;
        }

        public Player? ReadPlayerById(long id)
        {
            return MockDatabase.Players.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdatePlayer(Player player)
        {
            var existingPlayer = MockDatabase.Players.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.Name = player.Name;
                existingPlayer.Age = player.Age;
                existingPlayer.Dni = player.Dni;
                existingPlayer.Number = player.Number;
                existingPlayer.ListaTeam = player.ListaTeam;
                return true;
            }
            return false;
        }

        public bool DeletePlayerById(long id)
        {
            var existingPlayer = MockDatabase.Players.FirstOrDefault(p => p.Id == id);
            if (existingPlayer != null)
            {
                MockDatabase.Players.Remove(existingPlayer);
                return true;
            }
            return false;
        }

        public List<Player> GetAllPlayers()
        {
            return MockDatabase.Players;
        }
    }
}
