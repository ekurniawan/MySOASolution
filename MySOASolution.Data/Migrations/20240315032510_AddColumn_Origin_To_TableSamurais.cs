using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySOASolution.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn_Origin_To_TableSamurais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Samurais",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Samurais");
        }
    }
}
