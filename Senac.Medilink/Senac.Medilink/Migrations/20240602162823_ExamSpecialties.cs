using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Senac.Medilink.Migrations
{
    /// <inheritdoc />
    public partial class ExamSpecialties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "examSpecialty",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpecialtyId = table.Column<long>(type: "bigint", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_examSpecialty", x => x.id);
                    table.ForeignKey(
                        name: "FK_examSpecialty_specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "specialty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_examSpecialty_unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_examSpecialty_SpecialtyId_UnitId",
                table: "examSpecialty",
                columns: new[] { "SpecialtyId", "UnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_examSpecialty_UnitId",
                table: "examSpecialty",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "examSpecialty");
        }
    }
}
