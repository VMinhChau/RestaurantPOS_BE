using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantPOS.Migrations
{
    /// <inheritdoc />
    public partial class init_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BILL_DETAIL");

            migrationBuilder.DropTable(
                name: "ODER_TABLE");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BILL");

            migrationBuilder.DropTable(
                name: "TABLE");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "FOOD");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "FOOD");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "FOOD");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FOOD",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "FOOD",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FOOD",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "FOOD",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "FOOD",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "None.");

            migrationBuilder.AddColumn<float>(
                name: "averageRating",
                table: "FOOD",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "FOOD",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "FOOD",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isPromote",
                table: "FOOD",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "FOOD",
                type: "decimal(38,17)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    encryptedPassword = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gender = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    dateOfBirth = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    rank = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "COMMENT",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rating = table.Column<float>(type: "real", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foodId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMENT", x => x.id);
                    table.ForeignKey(
                        name: "FK_COMMENT_FOOD_foodId",
                        column: x => x.foodId,
                        principalTable: "FOOD",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_COMMENT_USER_userId",
                        column: x => x.userId,
                        principalTable: "USER",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "FAVORITEFOOD",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    foodId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAVORITEFOOD", x => x.id);
                    table.ForeignKey(
                        name: "FK_FAVORITEFOOD_FOOD_foodId",
                        column: x => x.foodId,
                        principalTable: "FOOD",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FAVORITEFOOD_USER_userId",
                        column: x => x.userId,
                        principalTable: "USER",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ORDER",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    adminId = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    totalPrice = table.Column<float>(type: "real", nullable: false),
                    purcharseId = table.Column<int>(type: "int", nullable: true),
                    createAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updateAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.id);
                    table.ForeignKey(
                        name: "FK_ORDER_USER_adminId",
                        column: x => x.adminId,
                        principalTable: "USER",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ORDER_USER_userId",
                        column: x => x.userId,
                        principalTable: "USER",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDERITEM",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(type: "int", nullable: true),
                    currrentPrice = table.Column<float>(type: "real", nullable: false),
                    quatity = table.Column<int>(type: "int", nullable: false),
                    foodId = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERITEM", x => x.id);
                    table.ForeignKey(
                        name: "FK_ORDERITEM_FOOD_foodId",
                        column: x => x.foodId,
                        principalTable: "FOOD",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ORDERITEM_ORDER_orderId",
                        column: x => x.orderId,
                        principalTable: "ORDER",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FOOD_categoryId",
                table: "FOOD",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENT_foodId",
                table: "COMMENT",
                column: "foodId");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENT_userId",
                table: "COMMENT",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_FAVORITEFOOD_foodId",
                table: "FAVORITEFOOD",
                column: "foodId");

            migrationBuilder.CreateIndex(
                name: "IX_FAVORITEFOOD_userId",
                table: "FAVORITEFOOD",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_adminId",
                table: "ORDER",
                column: "adminId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_userId",
                table: "ORDER",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERITEM_foodId",
                table: "ORDERITEM",
                column: "foodId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERITEM_orderId",
                table: "ORDERITEM",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FOOD_CATEGORY_categoryId",
                table: "FOOD",
                column: "categoryId",
                principalTable: "CATEGORY",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FOOD_CATEGORY_categoryId",
                table: "FOOD");

            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.DropTable(
                name: "COMMENT");

            migrationBuilder.DropTable(
                name: "FAVORITEFOOD");

            migrationBuilder.DropTable(
                name: "ORDERITEM");

            migrationBuilder.DropTable(
                name: "ORDER");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropIndex(
                name: "IX_FOOD_categoryId",
                table: "FOOD");

            migrationBuilder.DropColumn(
                name: "averageRating",
                table: "FOOD");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "FOOD");

            migrationBuilder.DropColumn(
                name: "image",
                table: "FOOD");

            migrationBuilder.DropColumn(
                name: "isPromote",
                table: "FOOD");

            migrationBuilder.DropColumn(
                name: "price",
                table: "FOOD");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "FOOD",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "FOOD",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FOOD",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FOOD",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FOOD",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "None.",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "FOOD",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "FOOD",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UnitPrice",
                table: "FOOD",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    VIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TABLE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PeopleCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TABLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_CUSTOMER_UserId",
                        column: x => x.UserId,
                        principalTable: "CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_CUSTOMER_UserId",
                        column: x => x.UserId,
                        principalTable: "CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_CUSTOMER_UserId",
                        column: x => x.UserId,
                        principalTable: "CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_CUSTOMER_UserId",
                        column: x => x.UserId,
                        principalTable: "CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BILL",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BILL_CUSTOMER_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ODER_TABLE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ODER_TABLE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ODER_TABLE_CUSTOMER_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ODER_TABLE_TABLE_TableId",
                        column: x => x.TableId,
                        principalTable: "TABLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BILL_DETAIL",
                columns: table => new
                {
                    BillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILL_DETAIL", x => new { x.BillId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_BILL_DETAIL_BILL_BillId",
                        column: x => x.BillId,
                        principalTable: "BILL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BILL_DETAIL_FOOD_FoodId",
                        column: x => x.FoodId,
                        principalTable: "FOOD",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BILL_CustomerId",
                table: "BILL",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BILL_DETAIL_FoodId",
                table: "BILL_DETAIL",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "CUSTOMER",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "CUSTOMER",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ODER_TABLE_CustomerId",
                table: "ODER_TABLE",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ODER_TABLE_TableId",
                table: "ODER_TABLE",
                column: "TableId");
        }
    }
}
