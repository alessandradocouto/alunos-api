using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlunosApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Age", "CreatedAt", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 23, new DateTime(2023, 10, 14, 21, 38, 46, 906, DateTimeKind.Local).AddTicks(5508), "mariapenha@gmail.com", "Maria Da Penha" },
                    { 2, 47, new DateTime(2023, 10, 14, 21, 38, 46, 906, DateTimeKind.Local).AddTicks(5523), "zefederico@hotmail.com", "Zé Federico" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Aluno",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
