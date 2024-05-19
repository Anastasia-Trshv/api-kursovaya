using Kursovaya.Core.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace api_курсовая.Controllers
{
    [ApiController]
    [Route("controller")]
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

        }
    }
}
