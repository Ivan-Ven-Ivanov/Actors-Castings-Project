using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class SoftDeletePropertiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Plays",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Castings",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CastingAgentProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ActorProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Soft delete");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Plays");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Castings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CastingAgentProfiles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ActorProfiles");
        }
    }
}
