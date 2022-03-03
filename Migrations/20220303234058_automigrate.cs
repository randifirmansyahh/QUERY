using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QUERY.Migrations
{
    public partial class automigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tb_Blog",
                columns: new[] { "Id", "Content", "CreateDate", "Image", "Status", "Title", "Username" },
                values: new object[] { "1", "kontennya", new DateTime(2022, 3, 4, 6, 40, 58, 205, DateTimeKind.Local).AddTicks(7654), "https://avatars.githubusercontent.com/u/87772215?v=4", true, "judulnya", null });

            migrationBuilder.InsertData(
                table: "Tb_Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Admin" },
                    { "2", "User" }
                });

            migrationBuilder.InsertData(
                table: "Tb_User",
                columns: new[] { "Username", "Email", "Name", "Password", "RolesId" },
                values: new object[] { "randi", "hehehe@gmail.com", "Randi Firmansyah", "randi", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tb_Blog",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Tb_Roles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Tb_Roles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Tb_User",
                keyColumn: "Username",
                keyValue: "randi");
        }
    }
}
