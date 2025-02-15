using Microsoft.EntityFrameworkCore;
using QuadLogic.Core.Models;
using QuadLogic.Data.Context;
using QuadLogic.Data.Repositories;
using Xunit;

namespace QuadLogic.Tests.Repositories
{
    public class DroneRepositoryTests
    {
        private readonly DbContextOptions<QuadLogicDbContext> _options;

        public DroneRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<QuadLogicDbContext>()
                .UseInMemoryDatabase(databaseName: "QuadLogicTestDb")
                .Options;
        }

        [Fact]
        public async Task GetAvailableDrones_ReturnsOnlyActiveDrones()
        {
            // Arrange
            using var context = new QuadLogicDbContext(_options);
            var repository = new DroneRepository(context);

            var activeDrone = new Drone
            {
                DroneId = "ACTIVE-1",
                Status = DroneStatus.Available, // Ensure this is an enum
                BatteryLevel = 85
            };

            var inactiveDrone = new Drone
            {
                DroneId = "INACTIVE-1",
                Status = DroneStatus.Maintenance, // Ensure this is an enum
                BatteryLevel = 50
            };

            await context.Drones.AddRangeAsync(activeDrone, inactiveDrone);
            await context.SaveChangesAsync();

            // Act
            var availableDrones = await repository.GetAvailableDronesAsync();

            // Assert
            Assert.NotNull(availableDrones);
            Assert.Single(availableDrones);
            Assert.Equal("ACTIVE-1", availableDrones.First().DroneId);
        }
    }
}