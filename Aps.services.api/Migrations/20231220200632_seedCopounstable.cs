using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aps.services.api.Migrations
{
    /// <inheritdoc />
    public partial class seedCopounstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Copouns",
                columns: new[] { "CopounId", "CopounCode", "DiscountAmount", "MinAmount" },
                values: new object[,]
                {
                    { 1, "10OFF", 10f, 40 },
                    { 2, "20OFF", 20f, 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Copouns",
                keyColumn: "CopounId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Copouns",
                keyColumn: "CopounId",
                keyValue: 2);
        }
    }
}
