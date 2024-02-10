using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LyricsApp.Infrastructure.EFCore.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class SongFavoriteProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Songs",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Songs");
        }
    }
}
