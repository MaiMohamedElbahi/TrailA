using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrailA.Migrations
{
    /// <inheritdoc />
    public partial class nn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mechanics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstimatedDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomersProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreferredContactMethod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersProfiles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PlateNumer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    CustomeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Customers_CustomeId",
                        column: x => x.CustomeId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Pending"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    MechanicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Mechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentServices",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentServices", x => new { x.ServiceId, x.AppointmentId });
                    table.ForeignKey(
                        name: "FK_AppointmentServices_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "12 Nile Street, Giza", "ahmed.hassan@example.com", "Ahmed Hassan", "01012345678" },
                    { 2, "25 Tahrir Street, Cairo", "mona.ali@example.com", "Mona Ali", "01023456789" },
                    { 3, "8 El - Nasr Street, Giza", "omar.samir @example.com", "Omar Samir", "01034567890" }
                });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "FullName", "HireDate", "Phone", "Specialization" },
                values: new object[,]
                {
                    { 1, "Karim Mostafa", new DateTime(2010, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01112345678", "Engine Repair" },
                    { 2, "Salma Ibrahim", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "01123456789", "Electrical Systems" },
                    { 3, "Youssef Adel", new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01134567890", "General Maintenance" },
                    { 4, "Youssef Adel", new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01134567890", "General Maintenance" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "EstimatedDuration", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Engine oil and oil filter replacement", 30, "Oil Change", 800m },
                    { 2, "Inspect brake pads, discs, and fluid", 45, "Brake Inspection", 500m },
                    { 3, "Test and replace the vehicle battery", 40, "Battery Replacement", 2200m },
                    { 4, "Test and replace the vehicle battery", 40, "Battery Replacement", 2200m },
                    { 5, "Test and replace the vehicle battery", 40, "Battery Replacement", 2200m }
                });

            migrationBuilder.InsertData(
                table: "CustomersProfiles",
                columns: new[] { "Id", "CustomerId", "DateTime", "PreferredContactMethod" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1995, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone" },
                    { 2, 2, new DateTime(1998, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Email" },
                    { 3, 3, new DateTime(1992, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CustomeId", "Make", "Mileage", "Model", "PlateNumer", "Year" },
                values: new object[,]
                {
                    { 1, 1, "Toyota", 45000, "Corolla", "GIZ-1234", 2022 },
                    { 2, 2, "Hyundai", 62000, "Elantra", "CAI-5678", 2021 },
                    { 3, 3, "Kia", 12000, "Sportage", "GIZ-9012", 2024 },
                    { 4, 3, "Kia", 12000, "Sportage", "GIZ-9112", 2024 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "ActualPrice", "AppointmentDate", "MechanicId", "Notes", "Status", "VehicleId" },
                values: new object[,]
                {
                    { 1, 800m, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Oil changed; vehicle checked", "Completed", 1 },
                    { 2, 0m, new DateTime(2026, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Customer reported a warning light", "Pending", 2 },
                    { 3, 0m, new DateTime(2026, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Customer requested cancellation", "Canceled", 3 },
                    { 4, 0m, new DateTime(2026, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Customer requested cancellation", "Canceled", 4 }
                });

            migrationBuilder.InsertData(
                table: "AppointmentServices",
                columns: new[] { "AppointmentId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_MechanicId",
                table: "Appointments",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_VehicleId",
                table: "Appointments",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentServices_AppointmentId",
                table: "AppointmentServices",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersProfiles_CustomerId",
                table: "CustomersProfiles",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomeId",
                table: "Vehicles",
                column: "CustomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_PlateNumer",
                table: "Vehicles",
                column: "PlateNumer",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentServices");

            migrationBuilder.DropTable(
                name: "CustomersProfiles");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Mechanics");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
