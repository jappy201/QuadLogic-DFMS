using System;

namespace QuadLogic.Core.Models
{
    public class Point
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Point() { }

        public Point(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}