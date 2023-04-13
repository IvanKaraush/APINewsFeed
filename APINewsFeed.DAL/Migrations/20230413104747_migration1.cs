using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APINewsFeed.DAL.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "createdIndex",
                table: "Posts",
                column: "created");

            migrationBuilder.CreateIndex(
                name: "titleIndex",
                table: "Posts",
                column: "title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "createdIndex",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "titleIndex",
                table: "Posts");
        }
    }
}
