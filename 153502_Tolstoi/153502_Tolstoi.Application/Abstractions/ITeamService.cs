using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Tolstoi.Domain.Entities;

namespace _153502_Tolstoi.Application.Abstractions
{
    public interface ITeamService : IBaseService<Team>
    {
        public Task TransferPlayerToTeamAsync(Player player, Team team);
    }
}
