using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektBDanych.Data.Migrations
{
    /// <inheritdoc />
    public partial class API3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "numberOfVotes",
                table: "Dziennik",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "numberOfVotes",
                table: "Dziennik",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
