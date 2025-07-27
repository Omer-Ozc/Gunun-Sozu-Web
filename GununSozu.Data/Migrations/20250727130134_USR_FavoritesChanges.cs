using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GununSozu.Data.Migrations
{
    /// <inheritdoc />
    public partial class USR_FavoritesChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "USR_Favorites",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "USR_Favorites");
        }
    }
}
