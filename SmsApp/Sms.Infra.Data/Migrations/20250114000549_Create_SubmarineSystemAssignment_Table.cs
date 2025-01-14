using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sms.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Create_SubmarineSystemAssignment_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubmarineSystemAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmarineId = table.Column<int>(type: "int", nullable: false),
                    SubmarineSystemId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmarineSystemAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmarineSystemAssignment_SubmarineSystems_SubmarineSystemId",
                        column: x => x.SubmarineSystemId,
                        principalTable: "SubmarineSystems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubmarineSystemAssignment_Submarines_SubmarineId",
                        column: x => x.SubmarineId,
                        principalTable: "Submarines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubmarineSystemAssignment_SubmarineId",
                table: "SubmarineSystemAssignment",
                column: "SubmarineId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmarineSystemAssignment_SubmarineSystemId",
                table: "SubmarineSystemAssignment",
                column: "SubmarineSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmarineSystemAssignment");
        }
    }
}
