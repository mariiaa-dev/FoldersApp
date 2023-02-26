using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoldersApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvidenceFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentFolderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvidenceFolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinalProductFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentFolderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalProductFolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimarySourceFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentFolderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimarySourceFolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentFolderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessFolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecondarySourceFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentFolderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondarySourceFolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GraphicProductFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessFolderId = table.Column<int>(type: "int", nullable: false),
                    FinalProductFolderId = table.Column<int>(type: "int", nullable: false),
                    CurrentFolderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicProductFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraphicProductFolders_FinalProductFolders_FinalProductFolderId",
                        column: x => x.FinalProductFolderId,
                        principalTable: "FinalProductFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GraphicProductFolders_ProcessFolders_ProcessFolderId",
                        column: x => x.ProcessFolderId,
                        principalTable: "ProcessFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimarySourceId = table.Column<int>(type: "int", nullable: false),
                    SecondarySourceId = table.Column<int>(type: "int", nullable: false),
                    CurrentFolderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceFolders_PrimarySourceFolders_PrimarySourceId",
                        column: x => x.PrimarySourceId,
                        principalTable: "PrimarySourceFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceFolders_SecondarySourceFolders_SecondarySourceId",
                        column: x => x.SecondarySourceId,
                        principalTable: "SecondarySourceFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DigitalImgFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceFolderId = table.Column<int>(type: "int", nullable: false),
                    EvidenceFolderId = table.Column<int>(type: "int", nullable: false),
                    GraphicProductFolderId = table.Column<int>(type: "int", nullable: false),
                    CurrentFolderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DigitalImgFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DigitalImgFolders_EvidenceFolders_EvidenceFolderId",
                        column: x => x.EvidenceFolderId,
                        principalTable: "EvidenceFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DigitalImgFolders_GraphicProductFolders_GraphicProductFolderId",
                        column: x => x.GraphicProductFolderId,
                        principalTable: "GraphicProductFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DigitalImgFolders_ResourceFolders_ResourceFolderId",
                        column: x => x.ResourceFolderId,
                        principalTable: "ResourceFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DigitalImgFolders_EvidenceFolderId",
                table: "DigitalImgFolders",
                column: "EvidenceFolderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DigitalImgFolders_GraphicProductFolderId",
                table: "DigitalImgFolders",
                column: "GraphicProductFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_DigitalImgFolders_ResourceFolderId",
                table: "DigitalImgFolders",
                column: "ResourceFolderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GraphicProductFolders_FinalProductFolderId",
                table: "GraphicProductFolders",
                column: "FinalProductFolderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GraphicProductFolders_ProcessFolderId",
                table: "GraphicProductFolders",
                column: "ProcessFolderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceFolders_PrimarySourceId",
                table: "ResourceFolders",
                column: "PrimarySourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceFolders_SecondarySourceId",
                table: "ResourceFolders",
                column: "SecondarySourceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DigitalImgFolders");

            migrationBuilder.DropTable(
                name: "EvidenceFolders");

            migrationBuilder.DropTable(
                name: "GraphicProductFolders");

            migrationBuilder.DropTable(
                name: "ResourceFolders");

            migrationBuilder.DropTable(
                name: "FinalProductFolders");

            migrationBuilder.DropTable(
                name: "ProcessFolders");

            migrationBuilder.DropTable(
                name: "PrimarySourceFolders");

            migrationBuilder.DropTable(
                name: "SecondarySourceFolders");
        }
    }
}
