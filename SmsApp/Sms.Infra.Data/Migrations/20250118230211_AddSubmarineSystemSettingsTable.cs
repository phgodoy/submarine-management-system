using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sms.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSubmarineSystemSettingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubmarineSystemSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmarineSystemId = table.Column<int>(type: "int", nullable: false),
                    SettingKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SettingValue = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmarineSystemSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmarineSystemSettings_SubmarineSystems_SubmarineSystemId",
                        column: x => x.SubmarineSystemId,
                        principalTable: "SubmarineSystems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubmarineSystemSettings_SubmarineSystemId",
                table: "SubmarineSystemSettings",
                column: "SubmarineSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmarineSystemSettings");
        }
    }
}
