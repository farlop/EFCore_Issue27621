using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp3.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[fGrowerAssignments](@customerCode varchar(50) = null, @year int = null, @weekNumber int = null, @familyCode varchar(50) = null)
RETURNS TABLE
AS 
RETURN
(
	SELECT 'c' AS CustomerCode, 2022 as Year, 1 as WeekNumber, 'f' as FamilyCode, 'GRW' as GrowerCode
)");
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrowerAssignmentView",
                columns: table => new
                {
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    FamilyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrowerCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "OrderRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    WeekNumber = table.Column<int>(type: "int", nullable: false),
                    FamilyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderRequirements_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderRequirementDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderRequirementId = table.Column<int>(type: "int", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequirementDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderRequirementDetails_OrderRequirements_OrderRequirementId",
                        column: x => x.OrderRequirementId,
                        principalTable: "OrderRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Code",
                table: "Customers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequirementDetails_OrderRequirementId",
                table: "OrderRequirementDetails",
                column: "OrderRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequirements_CustomerId",
                table: "OrderRequirements",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrowerAssignmentView");

            migrationBuilder.DropTable(
                name: "OrderRequirementDetails");

            migrationBuilder.DropTable(
                name: "OrderRequirements");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
