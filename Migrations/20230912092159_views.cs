using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4chanForum.Migrations
{
    public partial class views : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPinned",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Replies");

            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Threads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuotedReplyId",
                table: "Replies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Threads");

            migrationBuilder.DropColumn(
                name: "QuotedReplyId",
                table: "Replies");

            migrationBuilder.AddColumn<bool>(
                name: "isPinned",
                table: "Topics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Replies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
