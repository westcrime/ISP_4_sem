using _153502_Tolstoi.Domain.Abstractions;
using _153502_Tolstoi.Domain.Entities;
using _153502_Tolstoi.Application.Abstractions;

namespace _153502_Tolstoi.Application.Services
{
    public class TeamService : ITeamService
    {
        private IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(Team item)
        {
            await _unitOfWork.TeamRepository.AddAsync(item);
        }

        public async Task DeleteAsync(Team item)
        {
            await _unitOfWork.TeamRepository.DeleteAsync(item);
        }

        public async Task<List<Team>> GetAllAsync()
        {
            return await _unitOfWork.TeamRepository.ListAllAsync();
        }

        public async Task<Team> GetByIdAsync(string id)
        {
            return await _unitOfWork.TeamRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Team item)
        {
            await _unitOfWork.TeamRepository.UpdateAsync(item);
        }
        public async Task TransferPlayerToTeamAsync(Player player, Team team)
        {
            var currTeam = await _unitOfWork.TeamRepository.GetByIdAsync(player.TeamId);
            currTeam.Players.Remove(player);
            await _unitOfWork.TeamRepository.UpdateAsync(currTeam);

            team.Players.Add(player);
            await _unitOfWork.TeamRepository.UpdateAsync(team);
        }

        public async Task SeedDb()
        {
            await _unitOfWork.SeedDb();
        }
    }
}
