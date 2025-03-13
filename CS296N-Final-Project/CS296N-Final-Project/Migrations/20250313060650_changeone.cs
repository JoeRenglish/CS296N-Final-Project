using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CS296N_Final_Project.Migrations
{
    public partial class changeone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AspNetUsers_AppUserId1",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AppUserId1",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Characters");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Characters",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AppUserId",
                table: "Characters",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AspNetUsers_AppUserId",
                table: "Characters",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AspNetUsers_AppUserId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AppUserId",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Characters",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AppUserId1",
                table: "Characters",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AspNetUsers_AppUserId1",
                table: "Characters",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
