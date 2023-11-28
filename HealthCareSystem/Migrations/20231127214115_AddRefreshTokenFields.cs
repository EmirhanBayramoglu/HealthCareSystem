using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCareSystem.Migrations
{
    public partial class AddRefreshTokenFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e610487-b2ff-4bd5-9857-c5ec7e65b887", "4475b355-8331-4f58-9d12-39be0cf445d0", "Doctor", "DOCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24bcf271-d03e-4a2c-b36f-d997df6f672c", "35ae2b24-2667-46be-8a95-9c4ddf34e644", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9e30972c-0a00-41ed-a6f5-692cb070cbf5", "e7327546-ac46-4714-ac24-4522a0254f36", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e610487-b2ff-4bd5-9857-c5ec7e65b887");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24bcf271-d03e-4a2c-b36f-d997df6f672c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e30972c-0a00-41ed-a6f5-692cb070cbf5");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
    }
}
