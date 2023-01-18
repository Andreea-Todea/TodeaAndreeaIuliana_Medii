using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodeaAndreeaIuliana_Medii.Migrations
{
    public partial class Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Hotel");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Hotel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Hotel");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Hotel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
