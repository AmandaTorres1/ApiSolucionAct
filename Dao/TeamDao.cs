using Dao;
using Entity_library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dao_library
{
    public class TeamDao
    {
        public Team GetTeam(Team team)
        {
            return MockDatabase.Teams.FirstOrDefault(t => t.Name == team.Name);
        }
        public Team PostTeam(Team team)
        {
            if (team != null)
            {
                team.Id = MockDatabase.Teams.Count + 1;
                MockDatabase.Teams.Add(team);
                return team;
            }
            return null;
        }
        public Team PutTeam(Team team)
        {
            var existingTeam = MockDatabase.Teams.FirstOrDefault(t => t.Id == team.Id);
            if (existingTeam != null)
            {
                existingTeam.Name = team.Name;
                existingTeam.Categoty = team.Categoty;
                return existingTeam;
            }
            return null;
        }
        public List<Team> GetTeam()
        {
            return MockDatabase.Teams;
        }
        public bool DeleteTeam(Team team)
        {
            var existingTeam = MockDatabase.Teams.FirstOrDefault(t => t.Id == team.Id);
            if (existingTeam != null)
            {
                MockDatabase.Teams.Remove(existingTeam);
                return true;
            }
            return false;
        }

    }
}
