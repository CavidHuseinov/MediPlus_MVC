using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediPlus.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class allCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Sliders");
        }
    }
}
