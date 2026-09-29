using Microsoft.AspNetCore.Mvc;
using TodoAppKozmos.Core.Models;
using TodoAppKozmos.Core.Services;

namespace TodoAppKozmos.UI.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: /Todo
        public async Task<IActionResult> Index()
        {
            var todos = await _todoService.GetAllAsync();

            return View(todos);
        }

        // GET: /Todo/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Todo todo)
        {
            if (!ModelState.IsValid)
                return View(todo);

            await _todoService.AddAsync(todo);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Todo/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var todo = await _todoService.GetByIdAsync(id);

            if (todo == null)
                return NotFound();

            return View(todo);
        }

        // POST: /Todo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Todo todo)
        {
            if (id != todo.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(todo);

            var existingTodo = await _todoService.GetByIdAsync(id);

            if (existingTodo == null)
                return NotFound();

            await _todoService.UpdateAsync(todo);

            return RedirectToAction(nameof(Index));
        }

        // POST: /Todo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _todoService.GetByIdAsync(id);

            if (todo == null)
                return NotFound();

            await _todoService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: /Todo/Complete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Complete(int id)
        {
            var todo = await _todoService.GetByIdAsync(id);

            if (todo == null)
                return NotFound();

            todo.IsCompleted = !todo.IsCompleted;

            await _todoService.UpdateAsync(todo);

            return RedirectToAction(nameof(Index));
        }
    }
}
