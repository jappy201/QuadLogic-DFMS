using Microsoft.EntityFrameworkCore;
using QuadLogic.Data.Context;
using Xunit;
using System;

namespace QuadLogic.Tests
{
    public class DatabaseConnectionTests
    {
        [Fact]
        public void CanConnectToDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<QuadLogicDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=QuadLogicTestDb;Trusted_Connection=True;")
                .Options;
     
            try
            {
                // Act & Assert
                using var context = new QuadLogicDbContext(options);
                bool canConnect = context.Database.CanConnect();
                Assert.True(canConnect, "Failed to connect to the database.");
            }
            catch (Exception ex)
            {
                // Log the exception message
                Assert.True(false, $"Exception occurred while connecting to the database: {ex.Message}");
            }
        }
    }
}
