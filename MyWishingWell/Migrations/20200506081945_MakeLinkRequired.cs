using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWishingWell.Migrations
{
    public partial class MakeLinkRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "WishListItem",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "WishListItem",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
