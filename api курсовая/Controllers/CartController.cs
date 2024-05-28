using api_курсовая.Contracts;
using Kursovaya.Application.Services;
using Kursovaya.Core.Abstract;
using Kursovaya.Core.Model;
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


        [HttpGet]
        public async Task<ActionResult<List<Supply>>> GetUsersSupllies(string id) 
        {
            var sups = await cartService.GetCart(id);
            var response = sups.Select(s => new SuppliesResponse(s.Id, s.Name, s.Description, s.Picture, s.Type, s.Price));
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<string>> AddSupply(string userid, string supId)
        {
            await cartService.AddSupply(userid, supId);
            return Ok(supId);
        }



            [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteSupply(string usid,string supid)
        {
            return Ok(await cartService.DeleteSup(usid,supid));
        }

    }
}
