using api_курсовая.Contracts;
using Kursovaya.Core.Abstract;
using Kursovaya.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace api_курсовая.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SuppliesController : ControllerBase
    {
        private readonly ISuppliesServise suppliesServise;
        public SuppliesController(ISuppliesServise suppliesServise)
        {
            this.suppliesServise = suppliesServise;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuppliesResponse>>> GetSupplies()
        {
            var sup = await suppliesServise.GetAllSupplies();
            var response = sup.Select(s => new SuppliesResponse(s.Id, s.Name, s.Description, s.Picture, s.Type, s.Price));
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateSupply([FromBody] SuppliesRequest request)
        {
            var (sup, error) = Supply.Create(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.Picture,
                request.Type,
                request.Price
                );
            if(!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }
            else
            {
                await suppliesServise.CreateSupplies(sup);
                return Ok(sup.Id);
            }
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSupplies(Guid id, [FromBody] SuppliesRequest request)
        {
           var sup= await suppliesServise.UpdateSupply(id, request.Name,request.Description,request.Picture,request.Type,request.Price);
            return Ok(sup);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteSupply(Guid id)
        {
            return Ok(await suppliesServise.DeleteSupply(id));
        }
    }
}
