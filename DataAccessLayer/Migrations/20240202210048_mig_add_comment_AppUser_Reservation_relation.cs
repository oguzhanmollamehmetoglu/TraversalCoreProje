using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_comment_AppUser_Reservation_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserID = table.Column<int>(type: "int", nullable: false),
                    PersonCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewDestiantionID = table.Column<int>(type: "int", nullable: false),
                    NewDestinationDestiantionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_reservations_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_Destinations_NewDestinationDestiantionID",
                        column: x => x.NewDestinationDestiantionID,
                        principalTable: "Destinations",
                        principalColumn: "DestiantionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_AppUserID",
                table: "comments",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_AppUserID",
                table: "reservations",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_NewDestinationDestiantionID",
                table: "reservations",
                column: "NewDestinationDestiantionID");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_AspNetUsers_AppUserID",
                table: "comments",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_AspNetUsers_AppUserID",
                table: "comments");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropIndex(
                name: "IX_comments_AppUserID",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "comments");
        }
    }
}
