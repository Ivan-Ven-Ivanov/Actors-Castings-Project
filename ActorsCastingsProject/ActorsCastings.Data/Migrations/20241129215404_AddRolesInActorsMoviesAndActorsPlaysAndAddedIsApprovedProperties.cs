using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesInActorsMoviesAndActorsPlaysAndAddedIsApprovedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Plays",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the Play approved by Admin");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the Movie approved by Admin");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Castings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the Casting approved by Admin");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "ActorsPlays",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "The role of the actor in the play");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "ActorsMovies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "The role of the actor in the movie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Plays");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Castings");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "ActorsPlays");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "ActorsMovies");
        }
    }
}
