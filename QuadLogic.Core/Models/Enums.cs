namespace QuadLogic.Core.Models
{
    public enum DroneType
    {
        StandardQuadcopter,
        HeavyHexacopter,
        RapidQuadcopter
    }

    public enum DroneStatus
    {
        Available,
        InMission,
        Charging,
        Maintenance,
        Grounded
    }
}