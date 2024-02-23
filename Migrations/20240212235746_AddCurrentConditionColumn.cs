using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDB.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrentConditionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonVehicle");

            migrationBuilder.DropColumn(
                name: "EndingCondition",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ReasonForTrip",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "StartingCondition",
                table: "Vehicles",
                newName: "CurrentMileage");

            migrationBuilder.RenameColumn(
                name: "FuelLevel",
                table: "Vehicles",
                newName: "CurrentFuelLevel");

            migrationBuilder.RenameColumn(
                name: "EndingMileage",
                table: "Vehicles",
                newName: "CurrentCondition");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "CurrentMileage",
                table: "Vehicles",
                newName: "StartingCondition");

            migrationBuilder.RenameColumn(
                name: "CurrentFuelLevel",
                table: "Vehicles",
                newName: "FuelLevel");

            migrationBuilder.RenameColumn(
                name: "CurrentCondition",
                table: "Vehicles",
                newName: "EndingMileage");

            migrationBuilder.AddColumn<int>(
                name: "EndingCondition",
                table: "Vehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForTrip",
                table: "Vehicles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PersonVehicle",
                columns: table => new
                {
                    PersonsId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehiclesVIN = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonVehicle", x => new { x.PersonsId, x.VehiclesVIN });
                    table.ForeignKey(
                        name: "FK_PersonVehicle_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonVehicle_Vehicles_VehiclesVIN",
                        column: x => x.VehiclesVIN,
                        principalTable: "Vehicles",
                        principalColumn: "VIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonVehicle_VehiclesVIN",
                table: "PersonVehicle",
                column: "VehiclesVIN");
        }
    }
}
