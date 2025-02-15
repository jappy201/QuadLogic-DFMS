using Microsoft.AspNetCore.Mvc;
using QuadLogic.Core.Interfaces;
using QuadLogic.Core.Models;

namespace QuadLogic.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HubController : ControllerBase
    {
        private readonly IHubRepository _hubRepository;

        public HubController(IHubRepository hubRepository)
        {
            _hubRepository = hubRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hub>>> GetHubs()
        {
            var hubs = await _hubRepository.GetAllAsync();
            return Ok(hubs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hub>> GetHub(string id)
        {
            var hub = await _hubRepository.GetByIdAsync(id);
            if (hub == null) return NotFound();
            return Ok(hub);
        }
    }
}