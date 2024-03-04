using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTeam_1.Migrations
{
    /// <inheritdoc />
    public partial class IsPlayingadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPlaying",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPlaying",
                table: "Users");
        }
    }
}
