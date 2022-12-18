using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTask.Migrations.ProductsData
{
    /// <inheritdoc />
    public partial class PvnPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PvnPrice",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PvnPrice",
                table: "Product");
        }
    }
}
