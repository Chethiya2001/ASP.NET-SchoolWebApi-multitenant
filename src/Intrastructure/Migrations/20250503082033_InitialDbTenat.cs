using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbTenat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Multitenancy");

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "Multitenancy",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", nullable:false),
                    ConnectionString = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Latname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidUpTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_Identifier",
                schema: "Multitenancy",
                table: "Tenants",
                column: "Identifier",
                unique: true,
                filter: "[Identifier] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "Multitenancy");
        }
    }
}
