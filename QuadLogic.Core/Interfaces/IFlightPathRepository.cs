using QuadLogic.Core.Models;

namespace QuadLogic.Core.Interfaces
{
    public interface IFlightPathRepository : IRepository<FlightPath>
    {
        Task<IEnumerable<FlightPath>> GetActiveFlightPathsAsync();
        Task<IEnumerable<FlightPath>> GetFlightPathsByDroneAsync(string droneId);
        Task<IEnumerable<FlightPath>> GetFlightPathsByHubAsync(string hubId);
    }
}