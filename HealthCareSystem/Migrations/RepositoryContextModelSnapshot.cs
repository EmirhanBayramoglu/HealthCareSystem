﻿// <auto-generated />
using System;
using HealthCareSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthCareSystem.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HealthCareSystem.Models.Appointments", b =>
                {
                    b.Property<string>("AppointmentId")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("AppoStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AppointmentType")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("PrescriptionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("TcNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("AppointmentId");

                    b.HasIndex("AppointmentId")
                        .IsUnique();

                    b.HasIndex("DoctorId");

                    b.HasIndex("PrescriptionId")
                        .IsUnique();

                    b.HasIndex("TcNumber");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HealthCareSystem.Models.Doctors", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"), 1L, 1);

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorType")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HealthCareSystem.Models.Medicines", b =>
                {
                    b.Property<int>("MedicineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicineId"), 1L, 1);

                    b.Property<string>("MedicineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicineId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("HealthCareSystem.Models.Patients", b =>
                {
                    b.Property<string>("TcNumber")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TcNumber");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HealthCareSystem.Models.Prescription", b =>
                {
                    b.Property<string>("PrescriptionId")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Medicines")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientsTcNumber")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("TcNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrescriptionId");

                    b.HasIndex("PatientsTcNumber");

                    b.HasIndex("PrescriptionId")
                        .IsUnique();

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("HealthCareSystem.Models.Appointments", b =>
                {
                    b.HasOne("HealthCareSystem.Models.Doctors", "Doctors")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HealthCareSystem.Models.Prescription", "Prescription")
                        .WithOne("Appointments")
                        .HasForeignKey("HealthCareSystem.Models.Appointments", "PrescriptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HealthCareSystem.Models.Patients", "Patients")
                        .WithMany("Appointments")
                        .HasForeignKey("TcNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctors");

                    b.Navigation("Patients");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("HealthCareSystem.Models.Patients", b =>
                {
                    b.HasOne("HealthCareSystem.Models.Doctors", "Doctors")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("HealthCareSystem.Models.Prescription", b =>
                {
                    b.HasOne("HealthCareSystem.Models.Patients", "Patients")
                        .WithMany("Prescription")
                        .HasForeignKey("PatientsTcNumber");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("HealthCareSystem.Models.Doctors", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("HealthCareSystem.Models.Patients", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("HealthCareSystem.Models.Prescription", b =>
                {
                    b.Navigation("Appointments")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
