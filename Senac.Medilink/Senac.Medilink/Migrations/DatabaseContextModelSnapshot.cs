﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senac.Medilink.Data;

#nullable disable

namespace Senac.Medilink.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Senac.Medilink.Data.Entity.ProfessionalSpecialty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt");

                    b.Property<long>("ProfessionalId")
                        .HasColumnType("bigint");

                    b.Property<long>("SpecialtyId")
                        .HasColumnType("bigint");

                    b.Property<long>("UnitId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt");

                    b.HasKey("Id");

                    b.HasIndex("ProfessionalId");

                    b.HasIndex("SpecialtyId");

                    b.HasIndex("UnitId");

                    b.HasIndex("ProfessionalId", "UnitId");

                    b.ToTable("professionalSpecialty", (string)null);
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.ProfessionalWorkSchedules", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int")
                        .HasColumnName("dayOfWeek");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time(6)")
                        .HasColumnName("endTime");

                    b.Property<long>("ProfessionalId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProfessionalSpecialtyId")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time(6)")
                        .HasColumnName("startTime");

                    b.Property<long>("UnitId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DayOfWeek");

                    b.HasIndex("ProfessionalId");

                    b.HasIndex("UnitId");

                    b.HasIndex("ProfessionalId", "DayOfWeek");

                    b.ToTable("professionalWorkSchedules", (string)null);
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.Schedule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime")
                        .HasColumnName("endDate");

                    b.Property<int>("Form")
                        .HasColumnType("int")
                        .HasColumnName("form");

                    b.Property<long>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProfessionalId")
                        .HasColumnType("bigint");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("result");

                    b.Property<long>("SpecialtyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime")
                        .HasColumnName("startDate");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.Property<long>("UnitId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt");

                    b.HasKey("Id");

                    b.HasIndex("Active");

                    b.HasIndex("PatientId");

                    b.HasIndex("ProfessionalId");

                    b.HasIndex("Type");

                    b.HasIndex("UnitId");

                    b.HasIndex("ProfessionalId", "Status");

                    b.HasIndex("StartDate", "EndDate");

                    b.ToTable("schedule", (string)null);
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.Specialty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt");

                    b.HasKey("Id");

                    b.ToTable("specialty", (string)null);
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.Unit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt");

                    b.HasKey("Id");

                    b.ToTable("unit", (string)null);
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.User.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("document");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt");

                    b.HasKey("Id");

                    b.ToTable("patient", (string)null);
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.User.Professional", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("document");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<long>("SpecialtyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt");

                    b.HasKey("Id");

                    b.HasIndex("SpecialtyId");

                    b.ToTable("professional", (string)null);
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.User.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true)
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("createdAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updatedAt");

                    b.Property<int>("UserType")
                        .HasColumnType("int")
                        .HasColumnName("userType");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.ProfessionalSpecialty", b =>
                {
                    b.HasOne("Senac.Medilink.Data.Entity.User.Professional", "Professional")
                        .WithMany("ProfessionalSpecialties")
                        .HasForeignKey("ProfessionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senac.Medilink.Data.Entity.Specialty", "Specialty")
                        .WithMany("ProfessionalSpecialties")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senac.Medilink.Data.Entity.Unit", "Unit")
                        .WithMany("ProfessionalSpecialties")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professional");

                    b.Navigation("Specialty");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.ProfessionalWorkSchedules", b =>
                {
                    b.HasOne("Senac.Medilink.Data.Entity.User.Professional", "Professional")
                        .WithMany("WorkSchedules")
                        .HasForeignKey("ProfessionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senac.Medilink.Data.Entity.Unit", "Unit")
                        .WithMany("WorkSchedules")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professional");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.Schedule", b =>
                {
                    b.HasOne("Senac.Medilink.Data.Entity.User.Patient", "Patient")
                        .WithMany("Schedules")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senac.Medilink.Data.Entity.User.Professional", "Professional")
                        .WithMany("Schedules")
                        .HasForeignKey("ProfessionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senac.Medilink.Data.Entity.Unit", "Unit")
                        .WithMany("Schedules")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Professional");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.User.Patient", b =>
                {
                    b.HasOne("Senac.Medilink.Data.Entity.User.User", "User")
                        .WithOne("Patient")
                        .HasForeignKey("Senac.Medilink.Data.Entity.User.Patient", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.User.Professional", b =>
                {
                    b.HasOne("Senac.Medilink.Data.Entity.User.User", "User")
                        .WithOne("Professional")
                        .HasForeignKey("Senac.Medilink.Data.Entity.User.Professional", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Senac.Medilink.Data.Entity.Specialty", null)
                        .WithMany("Professionals")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.Specialty", b =>
                {
                    b.Navigation("ProfessionalSpecialties");

                    b.Navigation("Professionals");
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.Unit", b =>
                {
                    b.Navigation("ProfessionalSpecialties");

                    b.Navigation("Schedules");

                    b.Navigation("WorkSchedules");
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.User.Patient", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.User.Professional", b =>
                {
                    b.Navigation("ProfessionalSpecialties");

                    b.Navigation("Schedules");

                    b.Navigation("WorkSchedules");
                });

            modelBuilder.Entity("Senac.Medilink.Data.Entity.User.User", b =>
                {
                    b.Navigation("Patient")
                        .IsRequired();

                    b.Navigation("Professional")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
