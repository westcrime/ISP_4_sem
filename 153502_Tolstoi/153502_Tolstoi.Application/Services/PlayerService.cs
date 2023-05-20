using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Tolstoi.Application.Abstractions;
using _153502_Tolstoi.Domain.Abstractions;
using _153502_Tolstoi.Domain.Entities;

namespace _153502_Tolstoi.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private IUnitOfWork _unitOfWork;

        public PlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(Player item)
        {
             await _unitOfWork.PlayerRepository.AddAsync(item);
        }

        public async Task DeleteAsync(Player item)
        {
            await _unitOfWork.PlayerRepository.DeleteAsync(item);
        }

        public async Task<List<Player>> GetAllAsync()
        {
            return await _unitOfWork.PlayerRepository.ListAllAsync();
        }

        public async Task<Player> GetByIdAsync(string id)
        {
            return await _unitOfWork.PlayerRepository.GetByIdAsync(id);
        }

        public async Task SeedDb()
        {
            await _unitOfWork.SeedDb();
        }

        public async Task UpdateAsync(Player item)
        {
            await _unitOfWork.PlayerRepository.UpdateAsync(item);
        }
    }
}
