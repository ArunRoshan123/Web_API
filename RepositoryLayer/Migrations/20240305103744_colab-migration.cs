using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class colabmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColabTable",
                columns: table => new
                {
                    ColabId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColabEmail = table.Column<string>(nullable: true),
                    ColabTrash = table.Column<bool>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    NotesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColabTable", x => x.ColabId);
                    table.ForeignKey(
                        name: "FK_ColabTable_NoteTable_NotesId",
                        column: x => x.NotesId,
                        principalTable: "NoteTable",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColabTable_UserTable_userId",
                        column: x => x.userId,
                        principalTable: "UserTable",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColabTable_NotesId",
                table: "ColabTable",
                column: "NotesId");

            migrationBuilder.CreateIndex(
                name: "IX_ColabTable_userId",
                table: "ColabTable",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColabTable");
        }
    }
}
