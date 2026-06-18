using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BLL
{
    public class User:IUser
    {
        private readonly Idb _db;
        public User(Idb db)
        {
            _db = db;
        }
        
        public void AddUser(UsersDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (!IsValidEmail(user.Email))
            {
                throw new ArgumentException("Invalid email format");

            }
            if (!IsValidIsraeliID(user.UserId))
            {
                throw new ArgumentException("Invalid Israeli ID format");
            }
            var users = _db.GetAllUsers();
            if (users.Any(u => u.Email == user.Email)|| users.Any(u => u.UserId == user.UserId))
            {
                throw new ArgumentException("Email or ID already exists");
            }
            _db.AddUser(user);
        }

        public void DeleteUser(UsersDTO user)
        {
            var users = _db.GetAllUsers();
            if (!users.Any(u => u.Email == user.Email) || !users.Any(u => u.UserId == user.UserId))
            {
                throw new ArgumentException("User does not exist");
            }
            _db.DeleteUser(user);
        }

        public List<UsersDTO> GetAllUsers()
        {
            return _db.GetAllUsers();
        }

        public UsersDTO GetUser(string email, string password)
        {
            var user= _db.GetUser(email, password);
            if (user == null)
            {
                throw new ArgumentException("Invalid email or password");
            }
            return user;
        }

        public void UpdateUser(UsersDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (!IsValidEmail(user.Email))
            {
                throw new ArgumentException("Invalid email format");

            }
            if (!IsValidIsraeliID(user.UserId))
            {
                throw new ArgumentException("Invalid Israeli ID format");
            }
            var users = _db.GetAllUsers();
            if(!users.Any(u => u.Email == user.Email) || !users.Any(u => u.UserId == user.UserId))
            {
                throw new ArgumentException("User does not exist");
            }
            _db.UpdateUser(user);

        }
        public bool IsValidEmail(string email)
        {
            var validEmail = new EmailAddressAttribute();
            return validEmail.IsValid(email);
        }
        public bool IsValidIsraeliID(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length > 9 || !long.TryParse(id, out _))
                return false;
            id = id.PadLeft(9, '0');
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = int.Parse(id[i].ToString());
                int weight = (i % 2 == 0) ? 1 : 2;
                int step = digit * weight;
                if (step > 9)
                    step = (step / 10) + (step % 10);

                sum += step;
            }
            return sum % 10 == 0;
        }
    }
}
