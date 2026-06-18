using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public interface Idb
    {
        //Users
        public UsersDTO GetUser(string email, string password);
        //just for manager
        public List<UsersDTO> GetAllUsers();
        public void AddUser(UsersDTO user);
        public void UpdateUser(UsersDTO user);
        public void DeleteUser(UsersDTO user);
        //Categories
        public List<CategoriesDTO> GetCategory(UsersDTO user);
        public void AddCategory(CategoriesDTO category);
        public void UpdateCategory(CategoriesDTO category);
        public void DeleteCategory(CategoriesDTO category);
        //Tasks
        public List<TasksDTO> GetTasksByUser(UsersDTO user);
        public List<TasksDTO> GetTasksByTaskId(int id);
        public void AddTask(TasksDTO task);
        public void UpdateTask(TasksDTO task);
        public void DeleteTask(TasksDTO task);

    }
}
