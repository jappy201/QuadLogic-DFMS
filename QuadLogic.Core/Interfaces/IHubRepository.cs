using QuadLogic.Core.Models;

namespace QuadLogic.Core.Interfaces
{
    public interface IHubRepository : IRepository<Hub>
    {
        Task<IEnumerable<Hub>> GetAvailableHubsAsync();
        Task<IEnumerable<Hub>> GetHubsByStatusAsync(string status);
        Task UpdateSolarStatusAsync(string hubId, decimal solarStatus);
    }
}