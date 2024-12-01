using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class MadeRolePropertyNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "ActorsPlays",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The role of the actor in the play",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The role of the actor in the play");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "ActorsMovies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "The role of the actor in the movie",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The role of the actor in the movie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "ActorsPlays",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "The role of the actor in the play",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The role of the actor in the play");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "ActorsMovies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "The role of the actor in the movie",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "The role of the actor in the movie");
        }
    }
}
