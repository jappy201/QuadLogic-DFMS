using Microsoft.EntityFrameworkCore;
using QuadLogic.Core.Interfaces;
using QuadLogic.Core.Models;
using QuadLogic.Data.Context;

namespace QuadLogic.Data.Repositories
{
    public class FlightPathRepository : Repository<FlightPath>, IFlightPathRepository
    {
        public FlightPathRepository(QuadLogicDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<FlightPath>> GetActiveFlightPathsAsync()
        {
            return await _dbSet
                .Where(f => f.Status == "Active" && f.ActualEndTime == null)
                .Include(f => f.Drone)
                .Include(f => f.StartHub)
                .Include(f => f.EndHub)
                .ToListAsync();
        }

        public async Task<IEnumerable<FlightPath>> GetFlightPathsByDroneAsync(string droneId)
        {
            return await _dbSet
                .Where(f => f.DroneId == droneId)
                .Include(f => f.StartHub)
                .Include(f => f.EndHub)
                .OrderByDescending(f => f.StartTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<FlightPath>> GetFlightPathsByHubAsync(string hubId)
        {
            return await _dbSet
                .Where(f => f.StartHubId == hubId || f.EndHubId == hubId)
                .Include(f => f.Drone)
                .OrderByDescending(f => f.StartTime)
                .ToListAsync();
        }
    }
}