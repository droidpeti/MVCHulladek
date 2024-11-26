using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCHulladek.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Szolgaltatas",
                columns: table => new
                {
                    SzolgaltatasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jelentes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szolgaltatas", x => x.SzolgaltatasId);
                });

            migrationBuilder.CreateTable(
                name: "Lakig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Igeny = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SzolgaltatasId = table.Column<int>(type: "int", nullable: false),
                    Mennyiseg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lakig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lakig_Szolgaltatas_SzolgaltatasId",
                        column: x => x.SzolgaltatasId,
                        principalTable: "Szolgaltatas",
                        principalColumn: "SzolgaltatasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Naptar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SzolgaltatasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naptar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Naptar_Szolgaltatas_SzolgaltatasId",
                        column: x => x.SzolgaltatasId,
                        principalTable: "Szolgaltatas",
                        principalColumn: "SzolgaltatasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lakig_SzolgaltatasId",
                table: "Lakig",
                column: "SzolgaltatasId");

            migrationBuilder.CreateIndex(
                name: "IX_Naptar_SzolgaltatasId",
                table: "Naptar",
                column: "SzolgaltatasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lakig");

            migrationBuilder.DropTable(
                name: "Naptar");

            migrationBuilder.DropTable(
                name: "Szolgaltatas");
        }
    }
}
