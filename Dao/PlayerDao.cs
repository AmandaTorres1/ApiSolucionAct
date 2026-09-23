using Dao;
using Entity_library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dao_library
{
    public class PlayerDao
    {
        public Player GetPlayer (Player player)
        {
           return MockDatabase.Players.Find(p => p.Id == player.Id);
        }
        public Player PotPlayer(Player player)
        {
            if(player !=null)
            {
                player.Id = MockDatabase.Players.Count + 1;
                MockDatabase.Players.Add(player);
                return player;
            }
            return null;

        }
        public Player PutPlayer(Player player)
        {
            var existingPlayer = MockDatabase.Players.Find(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.Name = player.Name;
                existingPlayer.Age = player.Age;
                existingPlayer.Dni = player.Dni;
                existingPlayer.Number = player.Number;
                existingPlayer.ListaTeam = player.ListaTeam;


                return existingPlayer;
            }
            return null;
        }
        public List<Player> GetPlayer()
        {
            return MockDatabase.Players;
        }
        public bool DeletePlayer(Player player)
        {
            var existingPlayer = MockDatabase.Players.Find(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                MockDatabase.Players.Remove(existingPlayer);
                return true;
            }
            return false;
        }

    }
}
