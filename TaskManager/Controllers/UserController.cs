using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUser _userBLL;
        public UserController(IUser userBLL)
        {
            this._userBLL = userBLL;
        }
        // Credentials are sent in the request body, never in the URL,
        // so they don't end up in browser history or server logs.
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO credentials)
        {
            try
            {
                var user = _userBLL.GetUser(credentials.Email, credentials.Password);
                return Ok(UserResponseDTO.FromUser(user));
            }
            catch (ArgumentException)
            {
                // Same message for unknown email and wrong password,
                // so the API doesn't reveal which emails are registered.
                return Unauthorized("Invalid email or password");
            }
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            
            try
            {
                var users = _userBLL.GetAllUsers();
                return Ok(users.Select(UserResponseDTO.FromUser));
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
    }
}
