using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorBlog.Migrations
{
    /// <inheritdoc />
    public partial class resoRoleUnBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "role",
                table: "Users",
                type: "tinyint(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "Users",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
