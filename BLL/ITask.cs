using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ITask
    {
        public List<TasksDTO> GetTasksByUser(UsersDTO user);
        public List<TasksDTO> GetTasksByTaskId(int id);
        public void AddTask(TasksDTO task);
        public void UpdateTask(TasksDTO task);
        public void DeleteTask(TasksDTO task);
    }
}
