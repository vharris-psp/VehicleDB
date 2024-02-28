using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDB.Migrations
{
    /// <inheritdoc />
    public partial class NewSchema5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Addresses_ArrivalAddressId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Addresses_DepartureAddressId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "DepartureAddressId",
                table: "Trips",
                newName: "PickupLocationStoreID");

            migrationBuilder.RenameColumn(
                name: "ArrivalAddressId",
                table: "Trips",
                newName: "DropOffLocationStoreID");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_DepartureAddressId",
                table: "Trips",
                newName: "IX_Trips_PickupLocationStoreID");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_ArrivalAddressId",
                table: "Trips",
                newName: "IX_Trips_DropOffLocationStoreID");

            migrationBuilder.AddColumn<int>(
                name: "RentalLocationStoreID",
                table: "Vehicles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Trips",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId1",
                table: "Trips",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RentalLocation",
                columns: table => new
                {
                    StoreID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoreAddressId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalLocation", x => x.StoreID);
                    table.ForeignKey(
                        name: "FK_RentalLocation_Addresses_StoreAddressId",
                        column: x => x.StoreAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RentalLocationStoreID",
                table: "Vehicles",
                column: "RentalLocationStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_AddressId",
                table: "Trips",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_AddressId1",
                table: "Trips",
                column: "AddressId1");

            migrationBuilder.CreateIndex(
                name: "IX_RentalLocation_StoreAddressId",
                table: "RentalLocation",
                column: "StoreAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Addresses_AddressId",
                table: "Trips",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Addresses_AddressId1",
                table: "Trips",
                column: "AddressId1",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_RentalLocation_DropOffLocationStoreID",
                table: "Trips",
                column: "DropOffLocationStoreID",
                principalTable: "RentalLocation",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_RentalLocation_PickupLocationStoreID",
                table: "Trips",
                column: "PickupLocationStoreID",
                principalTable: "RentalLocation",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_RentalLocation_RentalLocationStoreID",
                table: "Vehicles",
                column: "RentalLocationStoreID",
                principalTable: "RentalLocation",
                principalColumn: "StoreID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Addresses_AddressId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Addresses_AddressId1",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_RentalLocation_DropOffLocationStoreID",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_RentalLocation_PickupLocationStoreID",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_RentalLocation_RentalLocationStoreID",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "RentalLocation");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_RentalLocationStoreID",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Trips_AddressId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_AddressId1",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "RentalLocationStoreID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "AddressId1",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "PickupLocationStoreID",
                table: "Trips",
                newName: "DepartureAddressId");

            migrationBuilder.RenameColumn(
                name: "DropOffLocationStoreID",
                table: "Trips",
                newName: "ArrivalAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_PickupLocationStoreID",
                table: "Trips",
                newName: "IX_Trips_DepartureAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_DropOffLocationStoreID",
                table: "Trips",
                newName: "IX_Trips_ArrivalAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Addresses_ArrivalAddressId",
                table: "Trips",
                column: "ArrivalAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Addresses_DepartureAddressId",
                table: "Trips",
                column: "DepartureAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
