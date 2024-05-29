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
        private readonly IAuthRepository _authRepository;
        public UserController(IUserServise userServise, IAuthRepository authRepository)
        {
            _userServise = userServise;
            _authRepository = authRepository;
        }

        [HttpGet]
        public async Task<ActionResult<UserResponse>> GetUser(string login, string password)
        {
            User us = await _userServise.GetUser(login,password);
            if (us.Id.ToString() != "00000000-0000-0000-0000-000000000000") {

                var refreshToken = await _authRepository.GenerateRefreshToken(us);
                var accessToken = await _authRepository.GenerateAccessToken(us);
                var response =  new UserResponse(us.Id, us.Name, us.Role, accessToken.ToString(), refreshToken.ToString());

                

                return Ok(response );

            }
            else
            {
               
                return BadRequest();
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
           
                await _userServise.CreateUser(us);


            var refreshToken = await _authRepository.GenerateRefreshToken(us);
            var accessToken = await _authRepository.GenerateAccessToken(us);

            var response = new UserResponse(us.Id, us.Name, us.Role, accessToken.ToString(), refreshToken.ToString());

            
            return Ok(response);
            
        }
        [HttpGet]
        public async Task<bool> CheckUserExist(string email)
        {
            bool response=await _userServise.CheckUserExist(email);
            return response;
        }
    }
}
