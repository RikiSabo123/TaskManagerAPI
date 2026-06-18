using AutoMapper;
using DAL.models;
using DTO;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnect : Idb
    {
        private readonly TaskManagerContext _TMdb;
        private readonly IMapper mapper;
        public DBConnect(TaskManagerContext TMdb, IMapper mapper)
        {
            _TMdb = TMdb;
            this.mapper = mapper;
        }
        public void AddCategory(CategoriesDTO category)
        {
            Category c=mapper.Map<Category>(category);
            _TMdb.Categories.Add(c);
            _TMdb.SaveChanges();
        }

        public void AddTask(TasksDTO task)
        {
            DAL.models.Task t = mapper.Map<DAL.models.Task>(task);
            _TMdb.Tasks.Add(t);
            _TMdb.SaveChanges();
        }

        public void AddUser(UsersDTO user)
        {
            User u = mapper.Map<User>(user);
            _TMdb.Users.Add(u);
            _TMdb.SaveChanges();
        }

        public void DeleteCategory(CategoriesDTO category)
        {
            Category c=mapper.Map<Category>(category);
            _TMdb.Categories.Remove(c);
            _TMdb.SaveChanges();
        }

        public void DeleteTask(TasksDTO task)
        {
            DAL.models.Task t = mapper.Map<DAL.models.Task>(task);
            _TMdb.Tasks.Remove(t);
            _TMdb.SaveChanges();
        }

        public void DeleteUser(UsersDTO user)
        {
            User u=mapper.Map<User>(user);
            _TMdb.Users.Remove(u);
            _TMdb.SaveChanges();
        }

        public List<UsersDTO> GetAllUsers()
        {
            List<User> users = _TMdb.Users.ToList();
            List<UsersDTO> usersDTO = mapper.Map<List<UsersDTO>>(users);
            return usersDTO;
        }

        public List<CategoriesDTO> GetCategory(UsersDTO user)
        {
            User u = mapper.Map<User>(user);
            List<Category> categories = _TMdb.Categories.Where(c => c.UserCode == u.UserCode).ToList();
            List<CategoriesDTO> categoriesDTO = mapper.Map<List<CategoriesDTO>>(categories);
            return categoriesDTO;

        }

        public List<TasksDTO> GetTasksByTaskId(int id)
        {
            DAL.models.Task t = _TMdb.Tasks.FirstOrDefault(t => t.TaskId == id);
            TasksDTO taskDTO = mapper.Map<TasksDTO>(t);
            return new List<TasksDTO> { taskDTO };

        }

        public List<TasksDTO> GetTasksByUser(UsersDTO user)
        {
            User u = mapper.Map<User>(user);
            List<DAL.models.Task> tasks = _TMdb.Tasks.Where(t => t.Category.UserCode == u.UserCode).ToList();
            List<TasksDTO> tasksDTO = mapper.Map<List<TasksDTO>>(tasks);
            return tasksDTO;

        }

        public UsersDTO GetUser(string email, string password)
        {
            User u = _TMdb.Users.FirstOrDefault(u => u.Email == email && u.UserPassword == password);
            if (u == null)
                return null;
            UsersDTO userDTO = mapper.Map<UsersDTO>(u);
            return userDTO;

        }

        public void UpdateCategory(CategoriesDTO category)
        {
            Category c = mapper.Map<Category>(category);
            _TMdb.Categories.Update(c);
            _TMdb.SaveChanges();

        }

        public void UpdateTask(TasksDTO task)
        {
            DAL.models.Task t = mapper.Map<DAL.models.Task>(task);
            _TMdb.Tasks.Update(t);
            _TMdb.SaveChanges();

        }

        public void UpdateUser(UsersDTO user)
        {
            User u = mapper.Map<User>(user);
            _TMdb.Users.Update(u);
            _TMdb.SaveChanges();

        }
    }
}
