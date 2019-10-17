using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpookyPark.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntertainmentTypes",
                columns: table => new
                {
                    EntertainmentTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    AgeRestriction = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntertainmentTypes", x => x.EntertainmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Attractions",
                columns: table => new
                {
                    AttractionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    EntertainmentTypeId = table.Column<int>(nullable: false),
                    DeathCount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractions", x => x.AttractionId);
                    table.ForeignKey(
                        name: "FK_Attractions_EntertainmentTypes_EntertainmentTypeId",
                        column: x => x.EntertainmentTypeId,
                        principalTable: "EntertainmentTypes",
                        principalColumn: "EntertainmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_EntertainmentTypeId",
                table: "Attractions",
                column: "EntertainmentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "EntertainmentTypes");
        }
    }
}
