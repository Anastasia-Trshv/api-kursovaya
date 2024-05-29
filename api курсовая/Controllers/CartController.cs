using api_курсовая.Contracts;
using Kursovaya.Application.Services;
using Kursovaya.Core.Abstract;
using Kursovaya.Core.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_курсовая.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<List<Supply>>> GetUsersSupllies(string id) 
        {
            var sups = await cartService.GetCart(id);
            var response = sups.Select(s => new SuppliesResponse(s.Id, s.Name, s.Description, s.Picture, s.Type, s.Price));
            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<string>> AddSupply(string userid, string supId)
        {
            await cartService.AddSupplyinCart(userid, supId);
            return Ok(supId);
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        public async Task<ActionResult<Guid>> DeleteSupply(string usid,string supid)
        {
            return Ok(await cartService.DeleteSup(usid,supid));
        }

    }
}
