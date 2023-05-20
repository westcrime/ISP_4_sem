using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Tolstoi.Domain.Entities;

namespace _153502_Tolstoi.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Team> TeamRepository { get; }
        IRepository<Player> PlayerRepository { get; }

        Task SeedDb();
    }
}
