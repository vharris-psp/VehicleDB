using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDB.Migrations
{
    /// <inheritdoc />
    public partial class NewSchema3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Persons_PersonId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_PersonId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Vehicles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Vehicles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_PersonId",
                table: "Vehicles",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Persons_PersonId",
                table: "Vehicles",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
