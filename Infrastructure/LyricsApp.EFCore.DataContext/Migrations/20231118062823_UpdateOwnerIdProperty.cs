using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LyricsApp.Infrastructure.EFCore.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOwnerIdProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Songs",
                newName: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Songs",
                newName: "Owner");
        }
    }
}
