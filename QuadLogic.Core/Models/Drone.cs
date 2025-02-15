// In QuadLogic.Core/Models/Drone.cs
using System;
using NetTopologySuite.Geometries;

namespace QuadLogic.Core.Models
{
    public class Drone : DroneBase
    {
        public string DroneId { get; set; }
        public DroneType Type { get; set; }
        public decimal BatteryLevel { get; set; }
        public DroneStatus Status { get; set; }
        public Point CurrentLocation { get; set; }
        public decimal PayloadCapacity { get; set; }
        public DateTime LastMaintenance { get; set; }
        public decimal InternalTemperature { get; set; }
        public decimal AltitudeMeters { get; set; }
        public decimal SpeedKmh { get; set; }
        public bool SolarPowerEnabled { get; set; }
        public decimal CurrentPayloadWeight { get; set; }
    }
}