using System;
using System.Collections.Generic;
using System.Text;
using TodoAppKozmos.Core.Models;

namespace TodoAppKozmos.Core.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo> GetByIdAsync(int id);
        Task AddAsync(Todo todo);
        Task UpdateAsync(Todo todo);
        Task DeleteAsync(int id);
    }
}
