using QuadLogic.Core.Models;

namespace QuadLogic.Core.Interfaces
{
    public interface IMaintenanceRecordRepository : IRepository<MaintenanceRecord>
    {
        Task<IEnumerable<MaintenanceRecord>> GetRecordsByDroneAsync(string droneId);
        Task<IEnumerable<MaintenanceRecord>> GetPendingMaintenanceAsync();
        Task<IEnumerable<MaintenanceRecord>> GetMaintenanceHistoryAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<MaintenanceRecord>> GetRequiresFollowUpAsync();
        Task<decimal> GetTotalMaintenanceCostAsync(string droneId);
    }
}