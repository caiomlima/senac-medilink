using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Senac.Medilink.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration_Remake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "specialty",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialty", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "unit",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unit", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userType = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    document = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.id);
                    table.ForeignKey(
                        name: "FK_patient_user_id",
                        column: x => x.id,
                        principalTable: "user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "professional",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    document = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    SpecialtyId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professional", x => x.id);
                    table.ForeignKey(
                        name: "FK_professional_specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "specialty",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_professional_user_id",
                        column: x => x.id,
                        principalTable: "user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "professionalSpecialty",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpecialtyId = table.Column<long>(type: "bigint", nullable: false),
                    ProfessionalId = table.Column<long>(type: "bigint", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professionalSpecialty", x => x.id);
                    table.ForeignKey(
                        name: "FK_professionalSpecialty_professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "professional",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_professionalSpecialty_specialty_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "specialty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_professionalSpecialty_unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "professionalWorkSchedules",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProfessionalId = table.Column<long>(type: "bigint", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    ProfessionalSpecialtyId = table.Column<long>(type: "bigint", nullable: false),
                    dayOfWeek = table.Column<int>(type: "int", nullable: false),
                    startTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    endTime = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professionalWorkSchedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_professionalWorkSchedules_professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "professional",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_professionalWorkSchedules_unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "schedule",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    ProfessionalId = table.Column<long>(type: "bigint", nullable: true),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialtyId = table.Column<long>(type: "bigint", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    form = table.Column<int>(type: "int", nullable: false),
                    result = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule", x => x.id);
                    table.ForeignKey(
                        name: "FK_schedule_patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_schedule_professional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "professional",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_schedule_unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "unit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_professional_SpecialtyId",
                table: "professional",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_professionalSpecialty_ProfessionalId",
                table: "professionalSpecialty",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_professionalSpecialty_ProfessionalId_UnitId",
                table: "professionalSpecialty",
                columns: new[] { "ProfessionalId", "UnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_professionalSpecialty_SpecialtyId",
                table: "professionalSpecialty",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_professionalSpecialty_UnitId",
                table: "professionalSpecialty",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_professionalWorkSchedules_dayOfWeek",
                table: "professionalWorkSchedules",
                column: "dayOfWeek");

            migrationBuilder.CreateIndex(
                name: "IX_professionalWorkSchedules_ProfessionalId",
                table: "professionalWorkSchedules",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_professionalWorkSchedules_ProfessionalId_dayOfWeek",
                table: "professionalWorkSchedules",
                columns: new[] { "ProfessionalId", "dayOfWeek" });

            migrationBuilder.CreateIndex(
                name: "IX_professionalWorkSchedules_UnitId",
                table: "professionalWorkSchedules",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_active",
                table: "schedule",
                column: "active");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_PatientId",
                table: "schedule",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_ProfessionalId",
                table: "schedule",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_ProfessionalId_status",
                table: "schedule",
                columns: new[] { "ProfessionalId", "status" });

            migrationBuilder.CreateIndex(
                name: "IX_schedule_startDate_endDate",
                table: "schedule",
                columns: new[] { "startDate", "endDate" });

            migrationBuilder.CreateIndex(
                name: "IX_schedule_type",
                table: "schedule",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_UnitId",
                table: "schedule",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_user_email",
                table: "user",
                column: "email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "professionalSpecialty");

            migrationBuilder.DropTable(
                name: "professionalWorkSchedules");

            migrationBuilder.DropTable(
                name: "schedule");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "professional");

            migrationBuilder.DropTable(
                name: "unit");

            migrationBuilder.DropTable(
                name: "specialty");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
