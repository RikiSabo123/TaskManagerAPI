using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUser
    {
        public UsersDTO GetUser(string email, string password);
        //just for manager
        public List<UsersDTO> GetAllUsers();
        public void AddUser(UsersDTO user);
        public void UpdateUser(UsersDTO user);
        public void DeleteUser(UsersDTO user);
    }
}
