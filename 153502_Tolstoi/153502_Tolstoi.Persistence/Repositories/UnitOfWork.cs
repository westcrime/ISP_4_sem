using System.Xml;
using _153502_Tolstoi.Domain.Abstractions;
using _153502_Tolstoi.Domain.Entities;
using _153502_Tolstoi.Persistence.Data;

namespace _153502_Tolstoi.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FirebaseDbClient _client;
        private readonly Lazy<IRepository<Team>> _teamRepository;
        private readonly Lazy<IRepository<Player>> _playerRepository;
        public UnitOfWork(FirebaseDbClient context)
        {
            _client = context;
            _teamRepository = new Lazy<IRepository<Team>>(() =>
                new Repository<Team>(_client));
            _playerRepository = new Lazy<IRepository<Player>>(() =>
                new Repository<Player>(_client));
        }
        
        IRepository<Team> IUnitOfWork.TeamRepository =>
            _teamRepository.Value;
        IRepository<Player> IUnitOfWork.PlayerRepository =>
            _playerRepository.Value;

        public async Task SeedDb()
        {
            var realMadrid = new Team()
            {
                Name = "Real Madrid",
                LeaguePoints = 56, 
                Photo = "realmadrid.png"
            };

            var barcelona = new Team()
            {
                Name = "Barcelona",
                LeaguePoints = 46,
                Photo = "barcelona.png"
            };

            var ronaldo = new Player()
            {
                Age = 33,
                Name = "Cristiano Ronaldo",
                Photo = "ronaldo.png",
                ScoredGoalsCount = 25,
                TeamId = realMadrid.Id
            };

            realMadrid.Players.Add(ronaldo);

            var messi = new Player()
            {
                Age = 35,
                Name = "Lionel Messi",
                Photo = "messi.png",
                ScoredGoalsCount = 9,
                TeamId = barcelona.Id
            };

            barcelona.Players.Add(messi);

            await _teamRepository.Value.AddAsync(realMadrid);
            await _teamRepository.Value.AddAsync(barcelona);

            await _playerRepository.Value.AddAsync(ronaldo);
            await _playerRepository.Value.AddAsync(messi);
        }
    }
}
