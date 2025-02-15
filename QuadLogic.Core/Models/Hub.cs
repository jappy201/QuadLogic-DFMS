using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;  // Changed from Geometrics to Geometries

namespace QuadLogic.Core.Models
{
    public class Hub
    {
        [Key]
        public string HubId { get; set; }
        public Point Location { get; set; }
        public string Status { get; set; }
        public int BatterySwapCapacity { get; set; }
        public decimal SolarPowerStatus { get; set; }
        public int CurrentOccupancy { get; set; }
        public bool MaintenanceCapability { get; set; }
        public decimal NetworkRange { get; set; }
        public int SecurityLevel { get; set; }
    }
}