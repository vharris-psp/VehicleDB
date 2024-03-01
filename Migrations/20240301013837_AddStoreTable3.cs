using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDB.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hours_Capacity",
                table: "Stores",
                newName: "Hours_Day");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Hours_ClosingTime",
                table: "Stores",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Hours_OpeningTime",
                table: "Stores",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hours_ClosingTime",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Hours_OpeningTime",
                table: "Stores");

            migrationBuilder.RenameColumn(
                name: "Hours_Day",
                table: "Stores",
                newName: "Hours_Capacity");
        }
    }
}
