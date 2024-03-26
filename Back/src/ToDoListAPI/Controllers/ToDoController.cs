using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Entities;
using ToDoListAPI.Service;

namespace ToDoListAPI.Controllers
{
    [Route("[controller]")]
    public class ToDoController : Controller
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly ToDoService _toDoService;

        public ToDoController(ILogger<ToDoController> logger, ToDoService toDoService)
        {
            _logger = logger;
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            var tasks = await _toDoService.GetAllTaskItems();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(string id)
        {
            var task = await _toDoService.GetTaskItemById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask([FromBody] TaskItem taskItem)
        {
            var task = await _toDoService.CreateTaskItem(taskItem);
            if (task == null)
            {
                return BadRequest();
            }
            return Ok(task);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTask([FromBody] TaskItem taskItem)
        {
            var updated = await _toDoService.UpdateTaskItem(taskItem);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(string id)
        {
            var deleted = await _toDoService.DeleteTaskItem(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}