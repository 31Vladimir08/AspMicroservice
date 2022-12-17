using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Expiration = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
