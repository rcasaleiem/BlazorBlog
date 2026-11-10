using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorBlog.Migrations
{
    /// <inheritdoc />
    public partial class tabellaCommentiAggiustata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseToComments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResponseToComments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    responseid = table.Column<int>(type: "int", nullable: false),
                    commentId = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseToComments", x => x.id);
                    table.ForeignKey(
                        name: "FK_ResponseToComments_Comments_responseid",
                        column: x => x.responseid,
                        principalTable: "Comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseToComments_responseid",
                table: "ResponseToComments",
                column: "responseid");
        }
    }
}
