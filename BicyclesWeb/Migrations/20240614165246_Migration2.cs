using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicyclesWeb.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bicycles",
                columns: table => new
                {
                    BicycleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycles", x => x.BicycleId);
                });

            migrationBuilder.CreateTable(
                name: "SupplierTypes",
                columns: table => new
                {
                    SupplierTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTypes", x => x.SupplierTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PartOrders",
                columns: table => new
                {
                    PartOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BicycleId = table.Column<int>(type: "int", nullable: false),
                    CountofBicycles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOrders", x => x.PartOrderId);
                    table.ForeignKey(
                        name: "FK_PartOrders_Bicycles_BicycleId",
                        column: x => x.BicycleId,
                        principalTable: "Bicycles",
                        principalColumn: "BicycleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Suppliers_SupplierTypes_SupplierTypeId",
                        column: x => x.SupplierTypeId,
                        principalTable: "SupplierTypes",
                        principalColumn: "SupplierTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                    table.ForeignKey(
                        name: "FK_Parts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "PartBicycles",
                columns: table => new
                {
                    PartBicycleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartId = table.Column<int>(type: "int", nullable: true),
                    BicycleId = table.Column<int>(type: "int", nullable: true),
                    QuantityRequired = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartBicycles", x => x.PartBicycleId);
                    table.ForeignKey(
                        name: "FK_PartBicycles_Bicycles_BicycleId",
                        column: x => x.BicycleId,
                        principalTable: "Bicycles",
                        principalColumn: "BicycleId");
                    table.ForeignKey(
                        name: "FK_PartBicycles_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartBicycles_BicycleId",
                table: "PartBicycles",
                column: "BicycleId");

            migrationBuilder.CreateIndex(
                name: "IX_PartBicycles_PartId",
                table: "PartBicycles",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_PartOrders_BicycleId",
                table: "PartOrders",
                column: "BicycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_SupplierId",
                table: "Parts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierTypeId",
                table: "Suppliers",
                column: "SupplierTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartBicycles");

            migrationBuilder.DropTable(
                name: "PartOrders");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Bicycles");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "SupplierTypes");
        }
    }
}
