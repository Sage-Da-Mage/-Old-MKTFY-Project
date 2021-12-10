using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MKTFY.Repositories.Migrations
{
    public partial class GetCategoryPickupInfoSearchTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQ",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListingUploads",
                columns: table => new
                {
                    ListingId = table.Column<Guid>(type: "uuid", nullable: false),
                    UploadId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingUploads", x => new { x.ListingId, x.UploadId });
                    table.ForeignKey(
                        name: "FK_ListingUploads_Listings_ListingId",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SearchItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SearchTerm = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cars & Vehicles" },
                    { 2, "Furniture" },
                    { 3, "Electronics" },
                    { 4, "Real Estate" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listings_CategoryId",
                table: "Listings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchItems_UserId",
                table: "SearchItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Category_CategoryId",
                table: "Listings",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Category_CategoryId",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "FAQ");

            migrationBuilder.DropTable(
                name: "ListingUploads");

            migrationBuilder.DropTable(
                name: "SearchItems");

            migrationBuilder.DropIndex(
                name: "IX_Listings_CategoryId",
                table: "Listings");
        }
    }
}
