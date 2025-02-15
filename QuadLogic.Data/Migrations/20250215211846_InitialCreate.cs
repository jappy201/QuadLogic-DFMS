using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuadLogic.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DroneBase",
                columns: table => new
                {
                    DroneId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BatteryLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PayloadCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastMaintenance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InternalTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AltitudeMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpeedKmh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SolarPowerEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CurrentPayloadWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DroneBase", x => x.DroneId);
                });

            migrationBuilder.CreateTable(
                name: "Drones",
                columns: table => new
                {
                    DroneId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentLocation_Latitude = table.Column<double>(type: "float", nullable: false),
                    CurrentLocation_Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drones", x => x.DroneId);
                });

            migrationBuilder.CreateTable(
                name: "Hubs",
                columns: table => new
                {
                    HubId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location_Latitude = table.Column<double>(type: "float", nullable: false),
                    Location_Longitude = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatterySwapCapacity = table.Column<int>(type: "int", nullable: false),
                    SolarPowerStatus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentOccupancy = table.Column<int>(type: "int", nullable: false),
                    MaintenanceCapability = table.Column<bool>(type: "bit", nullable: false),
                    NetworkRange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecurityLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hubs", x => x.HubId);
                });

            migrationBuilder.CreateTable(
                name: "HeavyHexacopters",
                columns: table => new
                {
                    DroneId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActiveBatteryCount = table.Column<int>(type: "int", nullable: false),
                    OmnidirectionalCameraStatus = table.Column<bool>(type: "bit", nullable: false),
                    FrameStressLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequiresPersonnelApproval = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeavyHexacopters", x => x.DroneId);
                    table.ForeignKey(
                        name: "FK_HeavyHexacopters_DroneBase_DroneId",
                        column: x => x.DroneId,
                        principalTable: "DroneBase",
                        principalColumn: "DroneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    RecordId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DroneId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaintenanceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiresFollowUp = table.Column<bool>(type: "bit", nullable: false),
                    PartsReplaced = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_DroneBase_DroneId",
                        column: x => x.DroneId,
                        principalTable: "DroneBase",
                        principalColumn: "DroneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RapidQuadcopters",
                columns: table => new
                {
                    DroneId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContraRotatingPropellers = table.Column<bool>(type: "bit", nullable: false),
                    SingleMissionBatteryMode = table.Column<bool>(type: "bit", nullable: false),
                    SecurityAltitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FixedWingMode = table.Column<bool>(type: "bit", nullable: false),
                    AerodynamicEfficiency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpeedProfile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencySpeedBoost = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RapidQuadcopters", x => x.DroneId);
                    table.ForeignKey(
                        name: "FK_RapidQuadcopters_DroneBase_DroneId",
                        column: x => x.DroneId,
                        principalTable: "DroneBase",
                        principalColumn: "DroneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardQuadcopters",
                columns: table => new
                {
                    DroneId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardQuadcopters", x => x.DroneId);
                    table.ForeignKey(
                        name: "FK_StandardQuadcopters_DroneBase_DroneId",
                        column: x => x.DroneId,
                        principalTable: "DroneBase",
                        principalColumn: "DroneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightPaths",
                columns: table => new
                {
                    PathId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DroneId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartHubId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndHubId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PayloadWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EconomyScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaintenanceFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPaths", x => x.PathId);
                    table.ForeignKey(
                        name: "FK_FlightPaths_DroneBase_DroneId",
                        column: x => x.DroneId,
                        principalTable: "DroneBase",
                        principalColumn: "DroneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightPaths_Hubs_EndHubId",
                        column: x => x.EndHubId,
                        principalTable: "Hubs",
                        principalColumn: "HubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightPaths_Hubs_StartHubId",
                        column: x => x.StartHubId,
                        principalTable: "Hubs",
                        principalColumn: "HubId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPaths_DroneId",
                table: "FlightPaths",
                column: "DroneId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPaths_EndHubId",
                table: "FlightPaths",
                column: "EndHubId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightPaths_StartHubId",
                table: "FlightPaths",
                column: "StartHubId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_DroneId",
                table: "MaintenanceRecords",
                column: "DroneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drones");

            migrationBuilder.DropTable(
                name: "FlightPaths");

            migrationBuilder.DropTable(
                name: "HeavyHexacopters");

            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "RapidQuadcopters");

            migrationBuilder.DropTable(
                name: "StandardQuadcopters");

            migrationBuilder.DropTable(
                name: "Hubs");

            migrationBuilder.DropTable(
                name: "DroneBase");
        }
    }
}
