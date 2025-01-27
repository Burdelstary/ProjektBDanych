using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektBDanych.Data.Migrations
{
    /// <inheritdoc />
    public partial class API4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "numberOfVotes",
                table: "Dziennik",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "numberOfVotes",
                table: "Dziennik",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
