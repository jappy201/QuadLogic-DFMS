using Microsoft.EntityFrameworkCore;
using QuadLogic.Core.Interfaces;
using QuadLogic.Core.Models;
using QuadLogic.Data.Context;

namespace QuadLogic.Data.Repositories
{
    public class HubRepository : Repository<Hub>, IHubRepository
    {
        public HubRepository(QuadLogicDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Hub>> GetAvailableHubsAsync()
        {
            return await _dbSet
                .Where(h => h.Status == "Available" && h.CurrentOccupancy < h.BatterySwapCapacity)
                .ToListAsync();
        }

        public async Task<IEnumerable<Hub>> GetHubsByStatusAsync(string status)
        {
            return await _dbSet
                .Where(h => h.Status == status)
                .ToListAsync();
        }

        public async Task UpdateSolarStatusAsync(string hubId, decimal solarStatus)
        {
            var hub = await GetByIdAsync(hubId);
            if (hub != null)
            {
                hub.SolarPowerStatus = solarStatus;
                await UpdateAsync(hub);
            }
        }
    }
}