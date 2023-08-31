using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LangCard.ContentLibrary.Adapter.Postgress.Migrations
{
    /// <inheritdoc />
    public partial class AddedToticItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "topics_item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TopicId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    TopicItemType = table.Column<int>(type: "integer", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topics_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_topics_item_topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_topics_item_TopicId",
                table: "topics_item",
                column: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "topics_item");
        }
    }
}
