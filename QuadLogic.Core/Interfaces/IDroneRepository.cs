using QuadLogic.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuadLogic.Core.Interfaces
{
    public interface IDroneRepository : IRepository<Drone>
    {
        Task<IEnumerable<Drone>> GetAvailableDronesAsync();
        Task<IEnumerable<Drone>> GetDronesByTypeAsync(DroneType droneType); // Change to DroneType
        Task UpdateBatteryLevelAsync(string droneId, decimal batteryLevel);
    }
}