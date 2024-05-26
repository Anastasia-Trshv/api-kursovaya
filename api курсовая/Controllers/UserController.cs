using api_курсовая.Authentication;
using api_курсовая.Contracts;
using api_курсовая.model;
using Kursovaya.Application.Services;
using Kursovaya.Core.Abstract;
using Kursovaya.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_курсовая.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {

        private readonly IUserServise _userServise;
        public UserController(IUserServise userServise)
        {
            _userServise = userServise;
        }

        [HttpGet]
        public async Task<ActionResult<UserResponse>> GetUser(string login, string password)
        {
            User us = await _userServise.GetUser(login,password);
            if (us.Id.ToString() != "00000000-0000-0000-0000-000000000000") {

                
                var response =  new UserResponse(us.Id, us.Name, us.Email, us.Role);

                var claims = new List<Claim> { new Claim(ClaimTypes.Name, us.Name), new Claim(ClaimTypes.Role, us.Role) };

                var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

                //return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
                return Ok(response);

            }
            else
            {
               
                return Unauthorized();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UserRequest request)
        {
            User us = new User(
                Guid.NewGuid(),
                request.Name,
                request.Email,
                request.Password,
                request.Role);

           int role = await _userServise.TurnRoleToId(us.Role);
                UserEntity user = new UserEntity(us.Name,us.Email,us.Password,role);


           
                await _userServise.CreateUser(us);
                return Ok(us.Id);
            ;
        }
        [HttpGet]
        public async Task<bool> CheckUserExist(string email)
        {
            bool response=await _userServise.CheckUserExist(email);
            return response;
        }
    }
}
