using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sms.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateSubmarineSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubmarineSystems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmarineId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SystemStatusId = table.Column<int>(type: "int", nullable: false),
                    LastMaintenanceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmarineSystems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubmarineSystems_Submarines_SubmarineId",
                        column: x => x.SubmarineId,
                        principalTable: "Submarines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubmarineSystems_SystemStatus_SystemStatusId",
                        column: x => x.SystemStatusId,
                        principalTable: "SystemStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubmarineSystem_Name",
                table: "SubmarineSystems",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_SubmarineSystems_SubmarineId",
                table: "SubmarineSystems",
                column: "SubmarineId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmarineSystems_SystemStatusId",
                table: "SubmarineSystems",
                column: "SystemStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemStatus_Name",
                table: "SystemStatus",
                column: "Name");

            migrationBuilder.InsertData(
               table: "SystemStatus",
               columns: new[] { "ID", "Name", "Description" },
               values: new object[,]
               {
                    { 1, "Operational", "The submarine is fully operational." },
                    { 2, "InMaintenance", "The submarine is undergoing maintenance." },
                    { 3, "Decommissioned", "The submarine has been decommissioned." }
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmarineSystems");

            migrationBuilder.DropTable(
                name: "SystemStatus");
        }
    }
}
