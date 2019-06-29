/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi57.Controllers
{
    [Route("api/[controller]")]
    public class TodoController57 : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi57.Models;

namespace TodoApi57.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Todo57Controller : ControllerBase
    {
        private readonly TodoContext57 _context;

        public Todo57Controller(TodoContext57 context)
        {
            _context = context;

            if (_context.TodoItems57.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems57.Add(new TodoItem57 { Name57 = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem57>>> GetTodoItems()
        {
            return await _context.TodoItems57.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem57>> GetTodoItem(long id)
        {
            var todoItem57 = await _context.TodoItems57.FindAsync(id);

            if (todoItem57 == null)
            {
                return NotFound();
            }

            return todoItem57;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<TodoItem57>> PostTodoItem(TodoItem57 item57)
        {
            _context.TodoItems57.Add(item57);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item57.Id }, item57);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem57 item57)
        {
            if (id != item57.Id)
            {
                return BadRequest();
            }

            _context.Entry(item57).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem57 = await _context.TodoItems57.FindAsync(id);

            if (todoItem57 == null)
            {
                return NotFound();
            }

            _context.TodoItems57.Remove(todoItem57);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
