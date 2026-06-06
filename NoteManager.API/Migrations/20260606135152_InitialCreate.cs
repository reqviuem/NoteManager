using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NoteManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "Id", "Content", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { new Guid("19a7d3e8-2c4f-4b61-96ad-5e7f8c1d2b90"), "Read about dependency injection in ASP.NET Core.", new DateTime(2026, 1, 5, 9, 0, 0, 0, DateTimeKind.Utc), "Note 5" },
                    { new Guid("3f7c2d91-8b4e-4a6f-9c12-7d5e8a1b2c34"), "Welcome to the notes app.", new DateTime(2026, 1, 1, 9, 0, 0, 0, DateTimeKind.Utc), "Note 1" },
                    { new Guid("6c1e9a44-5f2b-4d73-8a90-1e2f3b4c5d66"), "Remember to review the API endpoints.", new DateTime(2026, 1, 3, 9, 0, 0, 0, DateTimeKind.Utc), "Note 3" },
                    { new Guid("72e5a9c1-4d8f-4b30-8e17-9a2c6f3d1b77"), "Finish the controller methods and test them.", new DateTime(2026, 1, 7, 9, 0, 0, 0, DateTimeKind.Utc), "Note 7" },
                    { new Guid("a92d6f10-3b7a-4e85-b1c9-2f4d7a8e6c11"), "How are you doing today?", new DateTime(2026, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "Note 2" },
                    { new Guid("c8f14b62-7a3d-4e9c-b205-6d1f2a3b4c88"), "Prepare the database migration for the project.", new DateTime(2026, 1, 6, 9, 0, 0, 0, DateTimeKind.Utc), "Note 6" },
                    { new Guid("f4b82c17-9d6e-4f21-a7b3-8c0d1e2f9a55"), "Buy groceries after classes.", new DateTime(2026, 1, 4, 9, 0, 0, 0, DateTimeKind.Utc), "Note 4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");
        }
    }
}
