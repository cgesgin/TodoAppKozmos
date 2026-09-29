using System;
using System.Collections.Generic;
using System.Text;
using TodoAppKozmos.Core.Models;
using TodoAppKozmos.Core.Reposiories;
using Microsoft.EntityFrameworkCore;

namespace TodoAppKozmos.Repository.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            //return new List<Todo> { new Todo { Id = 1,
            //                                   Title = "Sample Todo",
            //                                   Description = "This is a sample todo item." ,
            //                                   CreatedDate = DateTime.Now ,
            //                                    DueDate = DateTime.Now ,
            //                                    IsCompleted=false
            //                                    }
            //                                   };
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task AddAsync(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Todo todo)
        {
            var existingTodo = await _context.Todos.FindAsync(todo.Id);

            if (existingTodo == null)
                return;

            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.DueDate = todo.DueDate;
            existingTodo.IsCompleted = todo.IsCompleted;

            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo is null)
                return;

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }
    }
}
