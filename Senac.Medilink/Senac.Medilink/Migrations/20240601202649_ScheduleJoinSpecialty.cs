using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Senac.Medilink.Migrations
{
    /// <inheritdoc />
    public partial class ScheduleJoinSpecialty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "result",
                table: "schedule",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_SpecialtyId",
                table: "schedule",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_specialty_SpecialtyId",
                table: "schedule",
                column: "SpecialtyId",
                principalTable: "specialty",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedule_specialty_SpecialtyId",
                table: "schedule");

            migrationBuilder.DropIndex(
                name: "IX_schedule_SpecialtyId",
                table: "schedule");

            migrationBuilder.UpdateData(
                table: "schedule",
                keyColumn: "result",
                keyValue: null,
                column: "result",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "result",
                table: "schedule",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
