using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _153502_Tolstoi.Domain.Abstractions;
using _153502_Tolstoi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace _153502_Tolstoi.Persistence.Repositories
{
    public class FakePlayerRepository : IRepository<Player>
    {
        List<Player> _list = new List<Player>();
        public FakePlayerRepository()
        {
            
        }

        public Task AddAsync(Player entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Player entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Player> FirstOrDefaultAsync(Expression<Func<Player, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Player, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Player>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            var list = _list.AsEnumerable();
            return list.ToList();
        }

        public async Task<IReadOnlyList<Player>>
            ListAsync(Expression<Func<Player, bool>> filter, CancellationToken
                cancellationToken = default, params Expression<Func<Player, object>>[]?
                includesProperties)
        {
            var data = _list.AsQueryable();
            return await data.Where(filter).ToListAsync(cancellationToken);
        }

        public Task UpdateAsync(Player entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        Task<List<Player>> IRepository<Player>.ListAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
