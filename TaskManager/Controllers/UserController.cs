using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private string adminEmail="r0548515188@gmail.com";
        private string adminPass = "1234";
        private readonly IUser _userBLL;
        public UserController(IUser userBLL)
        {
            this._userBLL = userBLL;
        }
        [HttpGet("GetUser")]
        public IActionResult GetUser(string email, string password)
        {
            try
            {
                var user = _userBLL.GetUser(email, password);
                if (user == null)
                {
                    return NotFound("User not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            
            try
            {
                var users = _userBLL.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddUser(UsersDTO user)
        {
            try
            {
                _userBLL.AddUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateUser(UsersDTO user)
        {
            try
            {
                _userBLL.UpdateUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteUser(UsersDTO user) {
            try
            {
                _userBLL.DeleteUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //public UsersDTO GetUser(string email, string password);
        ////just for manager
        //public List<UsersDTO> GetAllUsers();
        //public void AddUser(UsersDTO user);
        //public void UpdateUser(UsersDTO user);
        //public void DeleteUser(UsersDTO user);
    }
}
