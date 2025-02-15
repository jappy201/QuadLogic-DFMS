using Microsoft.EntityFrameworkCore;
using QuadLogic.Core.Interfaces;
using QuadLogic.Core.Models;
using QuadLogic.Data.Context;

namespace QuadLogic.Data.Repositories
{
    public class MaintenanceRecordRepository : Repository<MaintenanceRecord>, IMaintenanceRecordRepository
    {
        public MaintenanceRecordRepository(QuadLogicDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MaintenanceRecord>> GetRecordsByDroneAsync(string droneId)
        {
            return await _dbSet
                .Where(m => m.DroneId == droneId)
                .OrderByDescending(m => m.MaintenanceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<MaintenanceRecord>> GetPendingMaintenanceAsync()
        {
            return await _dbSet
                .Where(m => m.Status == "Pending")
                .OrderBy(m => m.MaintenanceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<MaintenanceRecord>> GetMaintenanceHistoryAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(m => m.MaintenanceDate >= startDate && m.MaintenanceDate <= endDate)
                .OrderByDescending(m => m.MaintenanceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<MaintenanceRecord>> GetRequiresFollowUpAsync()
        {
            return await _dbSet
                .Where(m => m.RequiresFollowUp)
                .OrderBy(m => m.MaintenanceDate)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalMaintenanceCostAsync(string droneId)
        {
            return await _dbSet
                .Where(m => m.DroneId == droneId)
                .SumAsync(m => m.Cost);
        }
    }
}