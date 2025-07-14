using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GununSozu.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QTE_Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QTE_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_Language",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QTE_Quotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QTE_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QTE_Quotes_QTE_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "QTE_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QTE_Quotes_SYS_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "SYS_Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "USR_Favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USR_Favorites_QTE_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "QTE_Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USR_Favorites_USR_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "USR_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USR_Preferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationTime1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationTime2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationFreq = table.Column<int>(type: "int", nullable: false),
                    PreferredCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USR_Preferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USR_Preferences_USR_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "USR_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QTE_Quotes_CategoryId",
                table: "QTE_Quotes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QTE_Quotes_LanguageId",
                table: "QTE_Quotes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_USR_Deliveries_QuoteId",
                table: "USR_Deliveries",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_USR_Deliveries_UserId",
                table: "USR_Deliveries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USR_Favorites_QuoteId",
                table: "USR_Favorites",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_USR_Favorites_UserId",
                table: "USR_Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USR_Preferences_UserId",
                table: "USR_Preferences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USR_Users_LanguageId",
                table: "USR_Users",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USR_Deliveries");

            migrationBuilder.DropTable(
                name: "USR_Favorites");

            migrationBuilder.DropTable(
                name: "USR_Preferences");

            migrationBuilder.DropTable(
                name: "QTE_Quotes");

            migrationBuilder.DropTable(
                name: "USR_Users");

            migrationBuilder.DropTable(
                name: "QTE_Categories");

            migrationBuilder.DropTable(
                name: "SYS_Language");
        }
    }
}
