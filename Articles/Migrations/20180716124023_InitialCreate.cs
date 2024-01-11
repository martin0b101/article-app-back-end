using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Articles.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "Articles",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //         CreatedAt = table.Column<DateTime>(nullable: false),
            //         UpdatedAt = table.Column<DateTime>(nullable: false),
            //         Title = table.Column<string>(maxLength: 255, nullable: false),
            //         Content = table.Column<string>(nullable: false),
            //         Date = table.Column<DateTime>(nullable: false),
            //         Published = table.Column<bool>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Articles", x => x.Id);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Comments",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(nullable: false)
            //             .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //         CreatedAt = table.Column<DateTime>(nullable: false),
            //         UpdatedAt = table.Column<DateTime>(nullable: false),
            //         ArticleId = table.Column<int>(nullable: true),
            //         Email = table.Column<string>(maxLength: 255, nullable: false),
            //         Title = table.Column<string>(maxLength: 255, nullable: false),
            //         Content = table.Column<string>(nullable: false),
            //         Date = table.Column<DateTime>(nullable: false),
            //         Published = table.Column<bool>(nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Comments", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Comments_Articles_ArticleId",
            //             column: x => x.ArticleId,
            //             principalTable: "Articles",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.SetNull);
            //     });

            // migrationBuilder.CreateIndex(
            //     name: "IX_Comments_ArticleId",
            //     table: "Comments",
            //     column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
