using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppTask.Migrations.ProductsData
{
    /// <inheritdoc />
    public partial class ProductPvn2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PvnPrice",
                table: "Product",
                type: "decimal",
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
