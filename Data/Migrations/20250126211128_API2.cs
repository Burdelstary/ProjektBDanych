using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektBDanych.Data.Migrations
{
    /// <inheritdoc />
    public partial class API2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypPodmiotu",
                table: "Dziennik",
                newName: "Voivodeship");

            migrationBuilder.RenameColumn(
                name: "LiczbaUczniow",
                table: "Dziennik",
                newName: "numberOfVotes");

            migrationBuilder.RenameColumn(
                name: "Gmina",
                table: "Dziennik",
                newName: "Surname");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Dziennik",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Dziennik");

            migrationBuilder.RenameColumn(
                name: "numberOfVotes",
                table: "Dziennik",
                newName: "LiczbaUczniow");

            migrationBuilder.RenameColumn(
                name: "Voivodeship",
                table: "Dziennik",
                newName: "TypPodmiotu");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Dziennik",
                newName: "Gmina");
        }
    }
}
