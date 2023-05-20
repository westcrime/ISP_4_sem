using _153502_Tolstoi.Domain.Abstractions;
using _153502_Tolstoi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Tolstoi.Persistence.Repositories
{
    public class FakeTeamRepository : IRepository<Team>
    {
        List<Team> _teams;
        public FakeTeamRepository()
        {
        }

        public Task AddAsync(Team entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Team entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Team> FirstOrDefaultAsync(Expression<Func<Team, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetByIdAsync(string id, CancellationToken cancellationToken = default, params Expression<Func<Team, object>>[]? includesProperties)
        {
            return Task.Run(() => _teams.Where(p => p.Id == id).FirstOrDefault());
        }

        public Task<Team> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Team> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Team>> ListAllAsync(CancellationToken
            cancellationToken = default)
        {
            return await Task.Run(() => _teams);
        }

        public Task<IReadOnlyList<Team>> ListAsync(Expression<Func<Team, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Team, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Team entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        Task<List<Team>> IRepository<Team>.ListAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
