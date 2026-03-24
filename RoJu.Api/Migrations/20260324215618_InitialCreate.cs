using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoJu.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    LastEditedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Description", "LastEditedBy", "Order", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Get the Postgres working", "Rohin", 1, "Done", "Set up Docker" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Create the first Endpoint", "Rohin", 2, "In Progress", "Build API" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
