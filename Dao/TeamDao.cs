using Entity_library;

namespace Dao_library
{
    public class TeamDao
    {
        public Team CreateTeam(Team team)
        {
            team.Id = MockDatabase.Teams.Count + 1;
            MockDatabase.Teams.Add(team);
            return team;
        }

        public Team? ReadTeamById(long id)
        {
            return MockDatabase.Teams.FirstOrDefault(t => t.Id == id);
        }

        public bool UpdateTeam(Team team)
        {
            var existingTeam = MockDatabase.Teams.FirstOrDefault(t => t.Id == team.Id);
            if (existingTeam != null)
            {
                existingTeam.Name = team.Name;
                existingTeam.Categoty = team.Categoty;
                return true;
            }
            return false;
        }

        public bool DeleteTeamById(long id)
        {
            var existingTeam = MockDatabase.Teams.FirstOrDefault(t => t.Id == id);
            if (existingTeam != null)
            {
                MockDatabase.Teams.Remove(existingTeam);
                return true;
            }
            return false;
        }

        public List<Team> GetAllTeams()
        {
            return MockDatabase.Teams;
        }
    }
}
