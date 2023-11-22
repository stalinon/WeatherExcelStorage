using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WeatherExcelStorage.Core.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    temperature = table.Column<decimal>(type: "numeric", nullable: false),
                    humidity = table.Column<int>(type: "integer", nullable: false),
                    dew = table.Column<decimal>(type: "numeric", nullable: false),
                    pressure = table.Column<int>(type: "integer", nullable: false),
                    winddirection = table.Column<int[]>(name: "wind_direction", type: "integer[]", nullable: false),
                    windspeed = table.Column<int>(name: "wind_speed", type: "integer", nullable: false),
                    overcast = table.Column<int>(type: "integer", nullable: true),
                    lowovercastpoint = table.Column<int>(name: "low_overcast_point", type: "integer", nullable: false),
                    horizontalsight = table.Column<int>(name: "horizontal_sight", type: "integer", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reports_created_at_updated_at",
                table: "reports",
                columns: new[] { "created_at", "updated_at" });

            migrationBuilder.CreateIndex(
                name: "IX_reports_datetime",
                table: "reports",
                column: "datetime",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reports");
        }
    }
}
