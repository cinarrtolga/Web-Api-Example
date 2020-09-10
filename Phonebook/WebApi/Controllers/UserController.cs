using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Get(UserRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetUserByEmailAndPassword(request.Email, request.Password);

                if (user != null)
                {
                    return Ok(new ResponseModel<Users> { Status = true, Message = "Operation successfully.", Object = user });
                }

                return Ok(new ResponseModel<Users> { Status = false, Message = "User couldn't found.", Object = null });
            }

            return ValidationProblem();
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserModel request)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(new Users
                {
                    Username = request.Username,
                    Email = request.Email,
                    Password = request.Password,
                    Status = request.Status
                });

                return Ok(new ResponseModel<Users> { Status = true, Message = "User updated.", Object = null });
            }

            return ValidationProblem();
        }

        [HttpPut]
        public ActionResult Put([FromBody] UserModel request)
        {
            if (ModelState.IsValid)
            {
                _userService.Add(new Users
                {
                    UserId = request.UserId,
                    Username = request.Username,
                    Email = request.Email,
                    Password = request.Password,
                    Status = request.Status
                });

                return Ok(new ResponseModel<Users> { Status = true, Message = "New user inserted.", Object = null });
            }

            return ValidationProblem();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            if(id != null)
            {
                var user = _userService.GetUserById(id);

                if(user != null)
                {
                    _userService.Delete(new Users
                    {
                        UserId = user.UserId,
                        Username = user.Username,
                        Email = user.Email,
                        Password = user.Password,
                        Status = user.Status
                    });

                    return Ok(new ResponseModel<Users> { Status = true, Message = "User deleted.", Object = null });
                }

                return Ok(new ResponseModel<Users> { Status = false, Message = "User couldn't found.", Object = null });
            }

            return ValidationProblem();
        }
    }
}
