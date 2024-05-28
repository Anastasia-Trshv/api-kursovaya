using api_курсовая.Authentication;
using Kursovaya.Core.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_курсовая.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepos;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepos = authRepository;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("CheckAccessToken")]
        public ActionResult<bool> CheckAcccessToken(string token)
        {
            return true;
        }
       
    }
}
