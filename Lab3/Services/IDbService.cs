using Lab3.Entities;

namespace Lab3.Services
{
    public interface IDbService
    {
        IEnumerable<FootballClub> GetAllClubs();
        IEnumerable<FootballPlayer> GetFootballPlayers(int id);
        void Init();
    }
}
