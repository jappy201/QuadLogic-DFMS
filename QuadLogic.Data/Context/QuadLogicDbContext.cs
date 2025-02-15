using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using QuadLogic.Core.Models;
using PointModel = QuadLogic.Core.Models.Point;

namespace QuadLogic.Data.Context
{
    public class Coordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class CoordinateConverter : ValueConverter<Coordinate, string>
    {
        public CoordinateConverter() : base(
            v => $"{v.Latitude},{v.Longitude}",
            v => ConvertToCoordinate(v))
        { }

        private static Coordinate ConvertToCoordinate(string v)
        {
            var parts = v.Split(',');
            return new Coordinate
            {
                Latitude = double.Parse(parts[0]),
                Longitude = double.Parse(parts[1])
            };
        }
    }

    public class QuadLogicDbContext : DbContext
    {
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Hub> Hubs { get; set; }
        public DbSet<PointModel> Points { get; set; }
        public DbSet<FlightPath> FlightPaths { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
        public DbSet<StandardQuadcopter> StandardQuadcopters { get; set; }
        public DbSet<HeavyHexacopter> HeavyHexacopters { get; set; }
        public DbSet<RapidQuadcopter> RapidQuadcopters { get; set; }

        public QuadLogicDbContext(DbContextOptions<QuadLogicDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=QuadLogicDb;Trusted_Connection=True;",
                    x => x.UseNetTopologySuite());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set the primary key for the Drone entity
            modelBuilder.Entity<DroneBase>()
                .HasKey(d => d.DroneId); // Ensure the primary key is set

            // Ignore the CurrentLocation property on the base type
            modelBuilder.Entity<DroneBase>()
                .Ignore(d => d.CurrentLocation);

            // Explicitly map the CurrentLocation property for the Drone entity
            modelBuilder.Entity<Drone>()
                .OwnsOne(d => d.CurrentLocation, cb =>
                {
                    cb.Property(p => p.Latitude).HasColumnType("float"); // Specify the SQL Server type
                    cb.Property(p => p.Longitude).HasColumnType("float"); // Specify the SQL Server type
                });

            modelBuilder.Entity<FlightPath>()
                .HasOne(f => f.Drone)
                .WithMany()
                .HasForeignKey(f => f.DroneId);

            modelBuilder.Entity<FlightPath>()
                .HasOne(f => f.StartHub)
                .WithMany()
                .HasForeignKey(f => f.StartHubId);

            modelBuilder.Entity<FlightPath>()
                .HasOne(f => f.EndHub)
                .WithMany()
                .HasForeignKey(f => f.EndHubId);

            modelBuilder.Entity<MaintenanceRecord>()
                .HasOne(m => m.Drone)
                .WithMany()
                .HasForeignKey(m => m.DroneId);

            modelBuilder.Entity<StandardQuadcopter>().ToTable("StandardQuadcopters");
            modelBuilder.Entity<HeavyHexacopter>().ToTable("HeavyHexacopters");
            modelBuilder.Entity<RapidQuadcopter>().ToTable("RapidQuadcopters");

            // Configure Point as an owned entity
            modelBuilder.Entity<Hub>()
                .OwnsOne(h => h.Location, cb =>
                {
                    cb.Property(p => p.Latitude).HasColumnType("float"); // Specify the SQL Server type
                    cb.Property(p => p.Longitude).HasColumnType("float"); // Specify the SQL Server type
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}
