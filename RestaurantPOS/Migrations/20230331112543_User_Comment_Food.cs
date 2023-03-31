using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantPOS.Migrations
{
    /// <inheritdoc />
    public partial class User_Comment_Food : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FOOD_CATEGORY_CategoryId",
                table: "FOOD");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "FOOD",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Points = table.Column<double>(type: "float", nullable: false),
                    Ranking = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COMMENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COMMENT_FOOD_FoodId",
                        column: x => x.FoodId,
                        principalTable: "FOOD",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMMENT_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMMENT_FoodId",
                table: "COMMENT",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENT_UserId",
                table: "COMMENT",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FOOD_CATEGORY_CategoryId",
                table: "FOOD",
                column: "CategoryId",
                principalTable: "CATEGORY",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FOOD_CATEGORY_CategoryId",
                table: "FOOD");

            migrationBuilder.DropTable(
                name: "COMMENT");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "FOOD",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FOOD_CATEGORY_CategoryId",
                table: "FOOD",
                column: "CategoryId",
                principalTable: "CATEGORY",
                principalColumn: "Id");
        }
    }
}
