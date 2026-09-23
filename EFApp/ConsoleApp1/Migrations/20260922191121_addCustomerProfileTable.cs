using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFApp.Migrations
{
    /// <inheritdoc />
    public partial class addCustomerProfileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customerProfiles",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerProfiles", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_customerProfiles_customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerProfiles");
        }
    }
}
