using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCareSystem.Migrations
{
    public partial class AddRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "503fb2da-e6e9-4993-8ceb-b994b6a854bb", "df646c14-a079-4f17-8e59-4a4315cb4497", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65345b62-bc52-4caa-9a53-08cf5766f3fe", "85d83fa3-246e-4918-8c2d-1c2d9b41f8f2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88231f07-a10f-4107-bf41-33d8c51cd329", "695d2e51-1a23-4699-af29-44b053e2eec3", "Doctor", "DOCTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "503fb2da-e6e9-4993-8ceb-b994b6a854bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65345b62-bc52-4caa-9a53-08cf5766f3fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88231f07-a10f-4107-bf41-33d8c51cd329");
        }
    }
}
