using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PreschoolDemo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diapers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ChildId = table.Column<Guid>(nullable: true),
                    TeacherId = table.Column<Guid>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diapers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diapers_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diapers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Contents = table.Column<string>(nullable: true),
                    ChildId = table.Column<Guid>(nullable: true),
                    TeacherId = table.Column<Guid>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meals_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Naps",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ChildId = table.Column<Guid>(nullable: true),
                    TeacherId = table.Column<Guid>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Naps_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Naps_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diapers_ChildId",
                table: "Diapers",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Diapers_TeacherId",
                table: "Diapers",
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
                name: "IX_Naps_ChildId",
                table: "Naps",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Naps_TeacherId",
                table: "Naps",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diapers");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Naps");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
