using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbSeederMachine.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedGuestManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vin = table.Column<int>(type: "int", nullable: false),
                    CarState = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoyaltyCards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastNameOfUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoyaltyCards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    AmountOfPersons = table.Column<int>(type: "int", nullable: false),
                    DateOfReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuggestedDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryManId = table.Column<int>(type: "int", nullable: false),
                    OrderState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientsRate = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryOrders_Employees_DeliveryManId",
                        column: x => x.DeliveryManId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Privileges = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employees_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_Employees_Employees_id",
                        column: x => x.Employees_id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentedCars",
                columns: table => new
                {
                    idOfRent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    StartOfRent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfRent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarState = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedCars", x => x.idOfRent);
                    table.ForeignKey(
                        name: "FK_RentedCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentedCars_Employees_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantsTables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    IsNotBroken = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainEmployee = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantsTables", x => x.TableId);
                    table.ForeignKey(
                        name: "FK_RestaurantsTables_Employees_MainEmployee",
                        column: x => x.MainEmployee,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLoyaltyCard = table.Column<int>(type: "int", nullable: true),
                    OrderDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_LoyaltyCards_IdLoyaltyCard",
                        column: x => x.IdLoyaltyCard,
                        principalTable: "LoyaltyCards",
                        principalColumn: "CardId");
                });

            migrationBuilder.CreateTable(
                name: "GuestManagements",
                columns: table => new
                {
                    GuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationID = table.Column<int>(type: "int", nullable: false),
                    LoyaltyCardID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    DeliveryOrderID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestManagements", x => x.GuestID);
                    table.ForeignKey(
                        name: "FK_GuestManagements_DeliveryOrders_DeliveryOrderID",
                        column: x => x.DeliveryOrderID,
                        principalTable: "DeliveryOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GuestManagements_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestManagements_LoyaltyCards_LoyaltyCardID",
                        column: x => x.LoyaltyCardID,
                        principalTable: "LoyaltyCards",
                        principalColumn: "CardId");
                    table.ForeignKey(
                        name: "FK_GuestManagements_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_GuestManagements_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_CarId",
                table: "DeliveryOrders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrders_DeliveryManId",
                table: "DeliveryOrders",
                column: "DeliveryManId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_Employees_id",
                table: "EmployeeTasks",
                column: "Employees_id");

            migrationBuilder.CreateIndex(
                name: "IX_GuestManagements_DeliveryOrderID",
                table: "GuestManagements",
                column: "DeliveryOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestManagements_EmployeeID",
                table: "GuestManagements",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestManagements_LoyaltyCardID",
                table: "GuestManagements",
                column: "LoyaltyCardID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestManagements_OrderID",
                table: "GuestManagements",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestManagements_ReservationID",
                table: "GuestManagements",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IdLoyaltyCard",
                table: "Orders",
                column: "IdLoyaltyCard");

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_CarId",
                table: "RentedCars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_DriverId",
                table: "RentedCars",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantsTables_MainEmployee",
                table: "RestaurantsTables",
                column: "MainEmployee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTasks");

            migrationBuilder.DropTable(
                name: "GuestManagements");

            migrationBuilder.DropTable(
                name: "RentedCars");

            migrationBuilder.DropTable(
                name: "RestaurantsTables");

            migrationBuilder.DropTable(
                name: "DeliveryOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "LoyaltyCards");
        }
    }
}
