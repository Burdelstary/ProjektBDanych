using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektBDanych.Data.Migrations
{
    /// <inheritdoc />
    public partial class API : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Dziennik");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Dziennik");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Dziennik");

            migrationBuilder.DropColumn(
                name: "GradeDate",
                table: "Dziennik");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Dziennik");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Dziennik");

            migrationBuilder.RenameColumn(
                name: "SchoolYear",
                table: "Dziennik",
                newName: "LiczbaUczniow");

            migrationBuilder.AddColumn<string>(
                name: "Gmina",
                table: "Dziennik",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KrajPochodzenia",
                table: "Dziennik",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gmina",
                table: "Dziennik");

            migrationBuilder.DropColumn(
                name: "KrajPochodzenia",
                table: "Dziennik");

            migrationBuilder.RenameColumn(
                name: "LiczbaUczniow",
                table: "Dziennik",
                newName: "SchoolYear");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Dziennik",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Dziennik",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Dziennik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "GradeDate",
                table: "Dziennik",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Dziennik",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Dziennik",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
