using Microsoft.EntityFrameworkCore;
using QuadLogic.Core.Interfaces;
using QuadLogic.Core.Models;
using QuadLogic.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuadLogic.Data.Repositories
{
    public class DroneRepository : Repository<Drone>, IDroneRepository
    {
        public DroneRepository(QuadLogicDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Drone>> GetAvailableDronesAsync()
        {
            return await _dbSet
                .Where(d => d.Status == DroneStatus.Available && d.BatteryLevel > 20)
                .ToListAsync();
        }

        public async Task<IEnumerable<Drone>> GetDronesByTypeAsync(DroneType droneType) // Implemented method
        {
            return await _dbSet
                .Where(d => d.Type == droneType) // Compare with DroneType enum
                .ToListAsync();
        }

        public async Task UpdateBatteryLevelAsync(string droneId, decimal batteryLevel)
        {
            var drone = await GetByIdAsync(droneId);
            if (drone != null)
            {
                drone.BatteryLevel = batteryLevel;
                await UpdateAsync(drone);
            }
        }
    }
}