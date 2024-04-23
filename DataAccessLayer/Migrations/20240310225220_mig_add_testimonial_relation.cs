using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_testimonial_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestimonialID",
                table: "comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "testimonials",
                columns: table => new
                {
                    TestimonialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentListLokasyon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testimonials", x => x.TestimonialID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_TestimonialID",
                table: "comments",
                column: "TestimonialID");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_testimonials_TestimonialID",
                table: "comments",
                column: "TestimonialID",
                principalTable: "testimonials",
                principalColumn: "TestimonialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_testimonials_TestimonialID",
                table: "comments");

            migrationBuilder.DropTable(
                name: "testimonials");

            migrationBuilder.DropIndex(
                name: "IX_comments_TestimonialID",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "TestimonialID",
                table: "comments");
        }
    }
}
