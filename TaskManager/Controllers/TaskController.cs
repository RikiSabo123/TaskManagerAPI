using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        private readonly ITask _taskBLL;
        public TaskController(ITask task)
        {
            this._taskBLL = task;
        }
        [HttpGet("GetTasksByUser")]
        public IActionResult GetTasksByUser(UsersDTO user)
        {
            _taskBLL.GetTasksByUser(user);
            return Ok();
        }
        [HttpGet("GetTasksByTaskId")]
        public IActionResult GetTasksByTaskId(int id) {
            _taskBLL.GetTasksByTaskId(id);
            return Ok();
        }
        [HttpPost]
        public IActionResult AddTask(TasksDTO task)
        {
            try
            {
                _taskBLL.AddTask(task);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateTask(TasksDTO task)
        {
            try
            {
                _taskBLL.UpdateTask(task);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteTask(TasksDTO task)
        {
            try
            {
                _taskBLL.DeleteTask(task);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public List<TasksDTO> GetTasksByUser(UsersDTO user);
        //public List<TasksDTO> GetTasksByTaskId(int id);
        //public void AddTask(TasksDTO task);
        //public void UpdateTask(TasksDTO task);
        //public void DeleteTask(TasksDTO task);
    }
}
