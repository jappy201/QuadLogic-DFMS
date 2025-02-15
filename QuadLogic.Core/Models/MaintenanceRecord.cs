using System;
using System.ComponentModel.DataAnnotations;

namespace QuadLogic.Core.Models
{
    public class MaintenanceRecord
    {
        [Key]
        public string RecordId { get; set; }
        public string DroneId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string MaintenanceType { get; set; }
        public string Description { get; set; }
        public string TechnicianId { get; set; }
        public decimal Cost { get; set; }
        public string Status { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Notes { get; set; }
        public bool RequiresFollowUp { get; set; }
        public string PartsReplaced { get; set; }

        public virtual DroneBase Drone { get; set; }
    }
}