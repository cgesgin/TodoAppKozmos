using System;
using System.Collections.Generic;
using System.Text;
using TodoAppKozmos.Core.Models;
using TodoAppKozmos.Core.Reposiories;
using TodoAppKozmos.Core.Services;

namespace TodoAppKozmos.Service.Services
{
    namespace TodoApp.Business.Services
    {
        public class TodoService : ITodoService
        {
            private readonly ITodoRepository _todoRepository;

            public TodoService(ITodoRepository todoRepository)
            {
                _todoRepository = todoRepository;
            }

            public async Task<List<Todo>> GetAllAsync()
            {
                return await _todoRepository.GetAllAsync();
            }

            public async Task<Todo> GetByIdAsync(int id)
            {
                return await _todoRepository.GetByIdAsync(id);
            }

            public async Task AddAsync(Todo todo)
            {
                if (string.IsNullOrWhiteSpace(todo.Title))
                    throw new ArgumentException("Title cannot be empty.");

                todo.CreatedDate = DateTime.Now;
                todo.IsCompleted = false;

                await _todoRepository.AddAsync(todo);
            }

            public async Task UpdateAsync(Todo todo)
            {
                if (string.IsNullOrWhiteSpace(todo.Title))
                    throw new ArgumentException("Title cannot be empty.");

                await _todoRepository.UpdateAsync(todo);
            }

            public async Task DeleteAsync(int id)
            {
                await _todoRepository.DeleteAsync(id);
            }
        }
    }
}
