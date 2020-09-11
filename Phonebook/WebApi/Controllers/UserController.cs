using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.DTO;
using Model.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService; 
        private readonly IConfiguration _config;

        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("token")]
        public ActionResult GetToken(UserRequestModel request)
        {
            if (!ModelState.IsValid)
                return Ok(new ResponseModel<object> { Status = false, Message = "Invalid request." });

            if (_userService.GetUserByEmailAndPassword(request.Email, request.Password) != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(180),
                    signingCredentials: credentials
                );

                var tokenDetail = new TokenModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpireDate = DateTime.Now.AddMinutes(180),
                    TokenType = "Bearer"
                };

                return Ok(new ResponseModel<object> { Status = true, Message = "Request successfully", Object = tokenDetail });
            }
            else
            {
                return BadRequest(new ResponseModel<object> { Status = false, Message = "Invalid User" });
            }
        }


        [HttpGet]
        [Authorize]
        public ActionResult Get(int? userId)
        {
            if (userId != null)
            {
                var user = _userService.GetUserById(userId);

                if (user != null)
                {
                    return Ok(new ResponseModel<Users> { Status = true, Message = "Operation successfully.", Object = user });
                }

                return Ok(new ResponseModel<Users> { Status = false, Message = "User couldn't found.", Object = null });
            }

            return ValidationProblem();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Post(UserModel request)
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
        [Authorize]
        public ActionResult Put(UserModel request)
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
        [Authorize]
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
