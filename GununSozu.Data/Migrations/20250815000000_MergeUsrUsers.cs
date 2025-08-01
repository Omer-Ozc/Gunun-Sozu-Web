using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GununSozu.Data.Migrations
{
    public partial class MergeUsrUsersIntoIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USR_Deliveries_USR_Users_UserId",
                table: "USR_Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_Favorites_USR_Users_UserId",
                table: "USR_Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_Preferences_USR_Users_UserId",
                table: "USR_Preferences");

            migrationBuilder.DropTable(
                name: "USR_Users");

            migrationBuilder.DropTable(
                name: "USR_Deliveries");

            migrationBuilder.CreateTable(
                name: "USR_Deliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WasOpened = table.Column<bool>(type: "bit", nullable: false),
                    WasLiked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USR_Deliveries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USR_Deliveries_QTE_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "QTE_Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USR_Deliveries_QuoteId",
                table: "USR_Deliveries",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_USR_Deliveries_UserId",
                table: "USR_Deliveries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_Favorites_AspNetUsers_UserId",
                table: "USR_Favorites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USR_Preferences_AspNetUsers_UserId",
                table: "USR_Preferences",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USR_Favorites_AspNetUsers_UserId",
                table: "USR_Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_USR_Preferences_AspNetUsers_UserId",
                table: "USR_Preferences");

            migrationBuilder.DropTable(
                name: "USR_Deliveries");

            migrationBuilder.CreateTable(
                name: "USR_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USR_Users_SYS_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "SYS_Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USR_Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WasOpened = table.Column<bool>(type: "bit", nullable: false),
                    WasLiked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USR_Deliveries_QTE_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "QTE_Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USR_Deliveries_USR_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "USR_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USR_Users_LanguageId",
                table: "USR_Users",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_USR_Deliveries_QuoteId",
                table: "USR_Deliveries",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_USR_Deliveries_UserId",
                table: "USR_Deliveries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_USR_Favorites_USR_Users_UserId",
                table: "USR_Favorites",
                column: "UserId",
                principalTable: "USR_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USR_Preferences_USR_Users_UserId",
                table: "USR_Preferences",
                column: "UserId",
                principalTable: "USR_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
