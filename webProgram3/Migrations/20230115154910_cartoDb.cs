using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webProgram3.Migrations
{
    public partial class cartoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartToDbId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartToDbId",
                table: "DiliveryType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartToDbId",
                table: "Adress",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CartToDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AdressId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiliveryTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartToDb", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartToDbId",
                table: "Products",
                column: "CartToDbId");

            migrationBuilder.CreateIndex(
                name: "IX_DiliveryType_CartToDbId",
                table: "DiliveryType",
                column: "CartToDbId");

            migrationBuilder.CreateIndex(
                name: "IX_Adress_CartToDbId",
                table: "Adress",
                column: "CartToDbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adress_CartToDb_CartToDbId",
                table: "Adress",
                column: "CartToDbId",
                principalTable: "CartToDb",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiliveryType_CartToDb_CartToDbId",
                table: "DiliveryType",
                column: "CartToDbId",
                principalTable: "CartToDb",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CartToDb_CartToDbId",
                table: "Products",
                column: "CartToDbId",
                principalTable: "CartToDb",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adress_CartToDb_CartToDbId",
                table: "Adress");

            migrationBuilder.DropForeignKey(
                name: "FK_DiliveryType_CartToDb_CartToDbId",
                table: "DiliveryType");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CartToDb_CartToDbId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CartToDb");

            migrationBuilder.DropIndex(
                name: "IX_Products_CartToDbId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_DiliveryType_CartToDbId",
                table: "DiliveryType");

            migrationBuilder.DropIndex(
                name: "IX_Adress_CartToDbId",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "CartToDbId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartToDbId",
                table: "DiliveryType");

            migrationBuilder.DropColumn(
                name: "CartToDbId",
                table: "Adress");
        }
    }
}
