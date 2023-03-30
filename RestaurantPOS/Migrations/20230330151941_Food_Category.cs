using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantPOS.Migrations
{
    /// <inheritdoc />
    public partial class Food_Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "FOOD");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "FOOD",
                newName: "AverageRating");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "FOOD",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "FOOD",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FOOD_CategoryId",
                table: "FOOD",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FOOD_CATEGORY_CategoryId",
                table: "FOOD",
                column: "CategoryId",
                principalTable: "CATEGORY",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FOOD_CATEGORY_CategoryId",
                table: "FOOD");

            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.DropIndex(
                name: "IX_FOOD_CategoryId",
                table: "FOOD");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "FOOD");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "FOOD");

            migrationBuilder.RenameColumn(
                name: "AverageRating",
                table: "FOOD",
                newName: "Category");

            migrationBuilder.AddColumn<int>(
                name: "UnitPrice",
                table: "FOOD",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
