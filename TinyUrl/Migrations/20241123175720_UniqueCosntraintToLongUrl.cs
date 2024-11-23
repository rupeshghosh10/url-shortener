using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyUrl.Migrations
{
    /// <inheritdoc />
    public partial class UniqueCosntraintToLongUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UrlMappings_UrlKey",
                table: "UrlMappings");

            migrationBuilder.CreateIndex(
                name: "IX_UrlMappings_UrlKey_LongUrl",
                table: "UrlMappings",
                columns: new[] { "UrlKey", "LongUrl" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UrlMappings_UrlKey_LongUrl",
                table: "UrlMappings");

            migrationBuilder.CreateIndex(
                name: "IX_UrlMappings_UrlKey",
                table: "UrlMappings",
                column: "UrlKey",
                unique: true);
        }
    }
}
