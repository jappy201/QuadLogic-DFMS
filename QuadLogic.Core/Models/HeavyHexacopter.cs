// In QuadLogic.Core/Models/HeavyHexacopter.cs
using System;
using NetTopologySuite.Geometries;
namespace QuadLogic.Core.Models
{
    public class HeavyHexacopter : DroneBase
    {
        public HeavyHexacopter()
        {
            Type = DroneType.HeavyHexacopter; // Correctly assign the DroneType
            PayloadCapacity = 25.0m; // Heavy capacity in kg
        }

        public int ActiveBatteryCount { get; set; }
        public bool OmnidirectionalCameraStatus { get; set; }
        public decimal FrameStressLevel { get; set; }
        public bool RequiresPersonnelApproval { get; set; } = true;
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