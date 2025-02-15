// In QuadLogic.Core/Models/StandardQuadcopter.cs
using System;
using NetTopologySuite.Geometries;

namespace QuadLogic.Core.Models
{
    public class StandardQuadcopter : DroneBase
    {
        public StandardQuadcopter()
        {
            Type = DroneType.StandardQuadcopter; // Correctly assign the DroneType
            PayloadCapacity = 15.0m; // Standard capacity in kg
        }

        public decimal BatteryLevel { get; set; }
        public DroneStatus Status { get; set; }
        public Point CurrentLocation { get; set; }
        public DateTime LastMaintenance { get; set; }
        public decimal InternalTemperature { get; set; }
        public decimal AltitudeMeters { get; set; }
        public decimal SpeedKmh { get; set; }
        public bool SolarPowerEnabled { get; set; }
        public decimal CurrentPayloadWeight { get; set; }
    }
}