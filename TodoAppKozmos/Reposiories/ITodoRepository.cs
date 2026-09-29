using System;
using System.Collections.Generic;
using System.Text;
using TodoAppKozmos.Core.Models;

namespace TodoAppKozmos.Core.Reposiories
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(int id);
        Task AddAsync(Todo todo);
        Task UpdateAsync(Todo todo);
        Task DeleteAsync(int id);
    }
}
