using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReservationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    show_schedule_id = table.Column<long>(type: "bigint", nullable: false),
                    movie_id = table.Column<long>(type: "bigint", nullable: false),
                    hall_id = table.Column<long>(type: "bigint", nullable: false),
                    theater_id = table.Column<long>(type: "bigint", nullable: false),
                    start_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    end_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    location = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    invoice = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    identification = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservations_halls_hall_id",
                        column: x => x.hall_id,
                        principalTable: "halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_shows_schedule_show_schedule_id",
                        column: x => x.show_schedule_id,
                        principalTable: "shows_schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_theaters_theater_id",
                        column: x => x.theater_id,
                        principalTable: "theaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Idx_Reservation_email",
                table: "reservations",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "Idx_Reservation_identification",
                table: "reservations",
                column: "identification");

            migrationBuilder.CreateIndex(
                name: "Idx_Reservation_MovieId_From_To_TheaterId_Status",
                table: "reservations",
                columns: new[] { "theater_id", "status", "start_at", "end_at" });

            migrationBuilder.CreateIndex(
                name: "IX_reservations_hall_id",
                table: "reservations",
                column: "hall_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_movie_id",
                table: "reservations",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_show_schedule_id",
                table: "reservations",
                column: "show_schedule_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");
        }
    }
}
