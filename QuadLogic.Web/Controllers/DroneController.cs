using Microsoft.AspNetCore.Mvc;
using QuadLogic.Core.Interfaces;
using QuadLogic.Core.Models;

namespace QuadLogic.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DroneController : ControllerBase
    {
        private readonly IDroneRepository _droneRepository;

        public DroneController(IDroneRepository droneRepository)
        {
            _droneRepository = droneRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DroneBase>>> GetDrones()
        {
            var drones = await _droneRepository.GetAllAsync();
            return Ok(drones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DroneBase>> GetDrone(string id)
        {
            var drone = await _droneRepository.GetByIdAsync(id);
            if (drone == null) return NotFound();
            return Ok(drone);
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<DroneBase>>> GetAvailableDrones()
        {
            var drones = await _droneRepository.GetAvailableDronesAsync();
            return Ok(drones);
        }

        [HttpPut("{id}/battery")]
        public async Task<IActionResult> UpdateBatteryLevel(string id, [FromBody] decimal batteryLevel)
        {
            await _droneRepository.UpdateBatteryLevelAsync(id, batteryLevel);
            return NoContent();
        }
    }
}