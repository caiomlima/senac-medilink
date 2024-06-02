using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Senac.Medilink.Migrations
{
    /// <inheritdoc />
    public partial class SpecialtyType_And_ScheduleResultNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedule_unit_UnitId",
                table: "schedule");

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "specialty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "UnitId",
                table: "schedule",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "SpecialtyId",
                table: "schedule",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_unit_UnitId",
                table: "schedule",
                column: "UnitId",
                principalTable: "unit",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedule_unit_UnitId",
                table: "schedule");

            migrationBuilder.DropColumn(
                name: "type",
                table: "specialty");

            migrationBuilder.AlterColumn<long>(
                name: "UnitId",
                table: "schedule",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SpecialtyId",
                table: "schedule",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_unit_UnitId",
                table: "schedule",
                column: "UnitId",
                principalTable: "unit",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
