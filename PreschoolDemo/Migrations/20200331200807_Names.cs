using Microsoft.EntityFrameworkCore.Migrations;

namespace PreschoolDemo.Migrations
{
    public partial class Names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChildName",
                table: "Naps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Naps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChildName",
                table: "Meals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Meals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChildName",
                table: "Diapers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Diapers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildName",
                table: "Naps");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Naps");

            migrationBuilder.DropColumn(
                name: "ChildName",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "ChildName",
                table: "Diapers");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Diapers");
        }
    }
}
