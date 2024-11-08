using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PiecesOfArt_Application_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class first_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "loyaltyCards",
                columns: table => new
                {
                    LoyaltyCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoyaltyCardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoyaltyCardDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loyaltyCards", x => x.LoyaltyCardId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAge = table.Column<int>(type: "int", nullable: false),
                    LoyaltyCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_loyaltyCards_LoyaltyCardId",
                        column: x => x.LoyaltyCardId,
                        principalTable: "loyaltyCards",
                        principalColumn: "LoyaltyCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pieceOfArts",
                columns: table => new
                {
                    PieceOfArtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pieceOfArts", x => x.PieceOfArtId);
                    table.ForeignKey(
                        name: "FK_pieceOfArts_Categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pieceOfArts_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[] { 1, "A 19th-century art movement characterized by small, thin brush strokes and emphasis on light and movement.", "Impressionism" });

            migrationBuilder.InsertData(
                table: "loyaltyCards",
                columns: new[] { "LoyaltyCardId", "LoyaltyCardDescription", "LoyaltyCardName" },
                values: new object[] { 1, "10%", "Bronze" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "LoyaltyCardId", "UserAge", "UserEmail", "UserName" },
                values: new object[] { 1, 1, 17, "Magdy@gmail.com", "Magdy" });

            migrationBuilder.InsertData(
                table: "pieceOfArts",
                columns: new[] { "PieceOfArtId", "Price", "PublicationDate", "Title", "categoryid", "userid" },
                values: new object[] { 1, 100.0, new DateTime(2024, 10, 23, 21, 36, 33, 463, DateTimeKind.Local).AddTicks(9932), "Starry Night", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_pieceOfArts_categoryid",
                table: "pieceOfArts",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_pieceOfArts_userid",
                table: "pieceOfArts",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LoyaltyCardId",
                table: "Users",
                column: "LoyaltyCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pieceOfArts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "loyaltyCards");
        }
    }
}
