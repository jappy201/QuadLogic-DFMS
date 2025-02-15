// In QuadLogic.Core/Models/RapidQuadcopter.cs
using System;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace QuadLogic.Core.Models
{
    public class RapidQuadcopter : DroneBase
    {
        public RapidQuadcopter()
        {
            Type = DroneType.RapidQuadcopter; // Correctly assign the DroneType
            PayloadCapacity = 5.0m; // Light capacity in kg
        }

        public bool ContraRotatingPropellers { get; set; }
        public bool SingleMissionBatteryMode { get; set; }
        public decimal SecurityAltitude { get; set; }
        public bool FixedWingMode { get; set; }
        public decimal AerodynamicEfficiency { get; set; }
        public string SpeedProfile { get; set; }
        public bool EmergencySpeedBoost { get; set; }
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