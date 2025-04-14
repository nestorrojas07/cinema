using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MovieListMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies_list",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    movie_id = table.Column<long>(type: "bigint", nullable: false),
                    theater_id = table.Column<long>(type: "bigint", nullable: false),
                    from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies_list", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movies_list_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movies_list_theaters_theater_id",
                        column: x => x.theater_id,
                        principalTable: "theaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Idx_MovieList_MovieId_From_To_TheaterId_Status",
                table: "movies_list",
                columns: new[] { "theater_id", "status", "from", "to" });

            migrationBuilder.CreateIndex(
                name: "IX_movies_list_movie_id",
                table: "movies_list",
                column: "movie_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies_list");
        }
    }
}
