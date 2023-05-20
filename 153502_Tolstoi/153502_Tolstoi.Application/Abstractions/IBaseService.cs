using _153502_Tolstoi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Tolstoi.Application.Abstractions
{
    public interface IBaseService<T> where T : Entity
    {
        Task<List<T>> GetAllAsync();

        Task SeedDb();

        Task<T> GetByIdAsync(string id);
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
