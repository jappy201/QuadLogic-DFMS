using System;
using System.ComponentModel.DataAnnotations;

namespace QuadLogic.Core.Models
{
    public class FlightPath
    {
        [Key]
        public string PathId { get; set; }
        public string DroneId { get; set; }
        public string StartHubId { get; set; }
        public string EndHubId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EstimatedEndTime { get; set; }
        public DateTime? ActualEndTime { get; set; }
        public decimal PayloadWeight { get; set; }
        public string Status { get; set; }
        public decimal EconomyScore { get; set; }
        public bool MaintenanceFlag { get; set; }

        public virtual DroneBase Drone { get; set; }
        public virtual Hub StartHub { get; set; }
        public virtual Hub EndHub { get; set; }
    }
}