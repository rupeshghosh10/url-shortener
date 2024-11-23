using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyUrl.Migrations
{
    /// <inheritdoc />
    public partial class RenameShortUrlToUrlKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortUrl",
                table: "UrlMappings",
                newName: "UrlKey");

            migrationBuilder.RenameIndex(
                name: "IX_UrlMappings_ShortUrl",
                table: "UrlMappings",
                newName: "IX_UrlMappings_UrlKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlKey",
                table: "UrlMappings",
                newName: "ShortUrl");

            migrationBuilder.RenameIndex(
                name: "IX_UrlMappings_UrlKey",
                table: "UrlMappings",
                newName: "IX_UrlMappings_ShortUrl");
        }
    }
}
