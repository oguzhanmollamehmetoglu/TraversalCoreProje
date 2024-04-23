using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_relation_destination_reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestiantionID",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationDestiantionID",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reservations_DestinationDestiantionID",
                table: "reservations",
                column: "DestinationDestiantionID");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_Destinations_DestinationDestiantionID",
                table: "reservations",
                column: "DestinationDestiantionID",
                principalTable: "Destinations",
                principalColumn: "DestiantionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_Destinations_DestinationDestiantionID",
                table: "reservations");

            migrationBuilder.DropIndex(
                name: "IX_reservations_DestinationDestiantionID",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "DestiantionID",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "DestinationDestiantionID",
                table: "reservations");
        }
    }
}
