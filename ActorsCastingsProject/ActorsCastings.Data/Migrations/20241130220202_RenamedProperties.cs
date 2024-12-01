using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsMovies_Actors_ActorProfileId",
                table: "ActorsMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsPlays_Actors_ActorProfileId",
                table: "ActorsPlays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsPlays",
                table: "ActorsPlays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsMovies",
                table: "ActorsMovies");

            migrationBuilder.DropColumn(
                name: "ActorProfileId",
                table: "ActorsPlays");

            migrationBuilder.DropColumn(
                name: "ActorProfileId",
                table: "ActorsMovies");

            migrationBuilder.AddColumn<Guid>(
                name: "ActorId",
                table: "ActorsPlays",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Foreign key to Actor");

            migrationBuilder.AddColumn<Guid>(
                name: "ActorId",
                table: "ActorsMovies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Foreign key to Actor");

            migrationBuilder.AlterColumn<Guid>(
                name: "ActorId",
                table: "ActorsCastings",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Foreign key to Actor",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Foreign key to ActorProfile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsPlays",
                table: "ActorsPlays",
                columns: new[] { "ActorId", "PlayId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsMovies",
                table: "ActorsMovies",
                columns: new[] { "ActorId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsMovies_Actors_ActorId",
                table: "ActorsMovies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsPlays_Actors_ActorId",
                table: "ActorsPlays",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsMovies_Actors_ActorId",
                table: "ActorsMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsPlays_Actors_ActorId",
                table: "ActorsPlays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsPlays",
                table: "ActorsPlays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsMovies",
                table: "ActorsMovies");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "ActorsPlays");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "ActorsMovies");

            migrationBuilder.AddColumn<Guid>(
                name: "ActorProfileId",
                table: "ActorsPlays",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Foreign key to ActorProfile");

            migrationBuilder.AddColumn<Guid>(
                name: "ActorProfileId",
                table: "ActorsMovies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Foreign key to ActorProfile");

            migrationBuilder.AlterColumn<Guid>(
                name: "ActorId",
                table: "ActorsCastings",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Foreign key to ActorProfile",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Foreign key to Actor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsPlays",
                table: "ActorsPlays",
                columns: new[] { "ActorProfileId", "PlayId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsMovies",
                table: "ActorsMovies",
                columns: new[] { "ActorProfileId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsMovies_Actors_ActorProfileId",
                table: "ActorsMovies",
                column: "ActorProfileId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsPlays_Actors_ActorProfileId",
                table: "ActorsPlays",
                column: "ActorProfileId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
