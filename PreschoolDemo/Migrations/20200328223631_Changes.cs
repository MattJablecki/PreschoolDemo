using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PreschoolDemo.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diapers_Children_ChildId",
                table: "Diapers");

            migrationBuilder.DropForeignKey(
                name: "FK_Diapers_Teachers_TeacherId",
                table: "Diapers");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Children_ChildId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Teachers_TeacherId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Naps_Children_ChildId",
                table: "Naps");

            migrationBuilder.DropForeignKey(
                name: "FK_Naps_Teachers_TeacherId",
                table: "Naps");

            migrationBuilder.DropIndex(
                name: "IX_Naps_ChildId",
                table: "Naps");

            migrationBuilder.DropIndex(
                name: "IX_Naps_TeacherId",
                table: "Naps");

            migrationBuilder.DropIndex(
                name: "IX_Meals_ChildId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_TeacherId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Diapers_ChildId",
                table: "Diapers");

            migrationBuilder.DropIndex(
                name: "IX_Diapers_TeacherId",
                table: "Diapers");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "Naps");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Naps");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "Diapers");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Diapers");

            migrationBuilder.AddColumn<Guid>(
                name: "Child_Id",
                table: "Naps",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Teacher_Id",
                table: "Naps",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Child_Id",
                table: "Meals",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Teacher_Id",
                table: "Meals",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Child_Id",
                table: "Diapers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Teacher_Id",
                table: "Diapers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Child_Id",
                table: "Naps");

            migrationBuilder.DropColumn(
                name: "Teacher_Id",
                table: "Naps");

            migrationBuilder.DropColumn(
                name: "Child_Id",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Teacher_Id",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Child_Id",
                table: "Diapers");

            migrationBuilder.DropColumn(
                name: "Teacher_Id",
                table: "Diapers");

            migrationBuilder.AddColumn<Guid>(
                name: "ChildId",
                table: "Naps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Naps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChildId",
                table: "Meals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Meals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ChildId",
                table: "Diapers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Diapers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Naps_ChildId",
                table: "Naps",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Naps_TeacherId",
                table: "Naps",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_ChildId",
                table: "Meals",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_TeacherId",
                table: "Meals",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Diapers_ChildId",
                table: "Diapers",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Diapers_TeacherId",
                table: "Diapers",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diapers_Children_ChildId",
                table: "Diapers",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diapers_Teachers_TeacherId",
                table: "Diapers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Children_ChildId",
                table: "Meals",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Teachers_TeacherId",
                table: "Meals",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Naps_Children_ChildId",
                table: "Naps",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Naps_Teachers_TeacherId",
                table: "Naps",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
