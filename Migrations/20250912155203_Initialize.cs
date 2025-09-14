using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Computers for work,and Gaming", "Labtops" },
                    { 2, "Latest Android and Ios", "Smart Phones" },
                    { 3, "Wired and wireless headphnes,AirPods", "HeadPhones" },
                    { 4, "Digital Cameras", "Cameras" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Fname", "Lname", "Password" },
                values: new object[,]
                {
                    { 1, "user@mail.com", "Ahmed", "Refaat", "1234" },
                    { 2, "user@mail.com", "Shahd", "Mohamed", "1234" },
                    { 3, "user@mail.com", "Youssef", "Abdelaziz", "1234" },
                    { 4, "user@mail.com", "Menna", "Mohamed", "1234" },
                    { 5, "user@mail.com", "omar", "Ali", "1234" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImagePath", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "corei7", "~/images/foldername", 30000, 5, "Labtop1" },
                    { 2, 1, "corei5", "~/images/foldername", 15000, 3, "Labtop2" },
                    { 3, 1, "corei3", "~/images/foldername", 10000, 2, "Labtop3" },
                    { 4, 1, "corei9", "~/images/foldername", 50000, 10, "Labtop4" },
                    { 5, 2, "128GB", "~/images/foldername", 4000, 15, "Phone1" },
                    { 6, 2, "200MP", "~/images/foldername", 6000, 10, "Phone2" },
                    { 7, 3, "More Stable Sound", "~/images/foldername", 200, 10, "Zuzg" },
                    { 8, 3, "Noise Canceling", "~/images/foldername", 3000, 5, "AirPods1" },
                    { 9, 4, "Mirrorless and 32.5MP", "~/images/foldername", 10000, 5, "Canon Eos R7" },
                    { 10, 4, "full-frame mirrorless and 33MP", "~/images/foldername", 12000, 4, "Canon Eos R7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
