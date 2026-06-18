using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Task : ITask
    {
        private readonly Idb _db;
        public Task(Idb db)
        {
            _db = db;
        }

        public void AddTask(TasksDTO task)
        {
            if(task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            task.RegistrationDate = DateOnly.FromDateTime(DateTime.Now);
            if (task.FromDate < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("From date must be in the future");
            }
            if (task.ToDate < task.FromDate)
            {
                throw new ArgumentException("End date must be after start date");
            }
            if(task.DoneDate<task.FromDate || task.DoneDate > task.ToDate)
            {
                throw new ArgumentException("Done date must be between Start date and End date");
            }
            _db.AddTask(task);


        }

        public void DeleteTask(TasksDTO task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            var t=_db.GetTasksByTaskId(task.TaskId).FirstOrDefault();
            if (t != null)
            {
                _db.DeleteTask(task);
            }
            else
            {
                throw new ArgumentException("Task not found");
            }
        }

        public List<TasksDTO> GetTasksByTaskId(int id)
        {
            var t=_db.GetTasksByTaskId(id);
            if (t == null || t.Count == 0)
            {
                return [];
            }
            return t;

        }

        public List<TasksDTO> GetTasksByUser(UsersDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var tasks = _db.GetTasksByUser(user);
            if (tasks == null)
            {
                return [];
            }
            return tasks;
        }

        public void UpdateTask(TasksDTO task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }
            var t = _db.GetTasksByTaskId(task.TaskId).FirstOrDefault();
            if (t != null)
            {
                if (task.ToDate < task.FromDate)
                {
                    throw new ArgumentException("End date must be after start date");
                }
                if (task.DoneDate < task.FromDate || task.DoneDate > task.ToDate)
                {
                    throw new ArgumentException("Done date must be between Start date and End date");
                }
                _db.UpdateTask(task);
            }
            else
            {
                throw new ArgumentException("Task not found");
            }
        }
    }
}
