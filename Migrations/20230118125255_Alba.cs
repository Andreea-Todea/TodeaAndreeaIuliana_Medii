using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodeaAndreeaIuliana_Medii.Migrations
{
    public partial class Alba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "Hotel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_CountryID",
                table: "Hotel",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Country_CountryID",
                table: "Hotel",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Country_CountryID",
                table: "Hotel");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_CountryID",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Hotel");
        }
    }
}
