using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCareSystem.Migrations
{
    public partial class HealthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.CheckConstraint("CK_DoctorType", "[DoctorType] IN ('General', 'Family')");
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    TcNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.TcNumber);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamillyDoctorRecord",
                columns: table => new
                {
                    RecordNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcNumber = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamillyDoctorRecord", x => x.RecordNo);
                    table.ForeignKey(
                        name: "FK_FamillyDoctorRecord_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamillyDoctorRecord_Patients_TcNumber",
                        column: x => x.TcNumber,
                        principalTable: "Patients",
                        principalColumn: "TcNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false, defaultValueSql: "NEWID()"),
                    TcNumber = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    MedicinesMedicineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescription_Medicines_MedicinesMedicineId",
                        column: x => x.MedicinesMedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId");
                    table.ForeignKey(
                        name: "FK_Prescription_Patients_TcNumber",
                        column: x => x.TcNumber,
                        principalTable: "Patients",
                        principalColumn: "TcNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TcNumber = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    AppointmentType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrescriptionId = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    AppoStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.CheckConstraint("CK_AppoStatus", "[AppoStatus] IN ('Waiting', 'Active', 'Ended', 'Canceled')");
                    table.CheckConstraint("CK_AppointmentType", "[AppointmentType] IN ('General', 'Family')");
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_TcNumber",
                        column: x => x.TcNumber,
                        principalTable: "Patients",
                        principalColumn: "TcNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionLists",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionId = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionLists_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionLists_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PrescriptionId",
                table: "Appointments",
                column: "PrescriptionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TcNumber",
                table: "Appointments",
                column: "TcNumber");

            migrationBuilder.CreateIndex(
                name: "IX_FamillyDoctorRecord_DoctorId",
                table: "FamillyDoctorRecord",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_FamillyDoctorRecord_TcNumber",
                table: "FamillyDoctorRecord",
                column: "TcNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_MedicinesMedicineId",
                table: "Prescription",
                column: "MedicinesMedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_TcNumber",
                table: "Prescription",
                column: "TcNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionLists_MedicineId",
                table: "PrescriptionLists",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionLists_PrescriptionId",
                table: "PrescriptionLists",
                column: "PrescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "FamillyDoctorRecord");

            migrationBuilder.DropTable(
                name: "PrescriptionLists");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
