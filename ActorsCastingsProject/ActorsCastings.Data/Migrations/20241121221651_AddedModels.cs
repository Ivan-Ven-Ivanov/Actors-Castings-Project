using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ActorProfile_ActorProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CastingAgentProfile_CastingAgentProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ActorProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CastingAgentProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorProfile",
                table: "ActorProfile");

            migrationBuilder.RenameTable(
                name: "ActorProfile",
                newName: "ActorProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CastingAgentProfile",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Casting agent profile unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "CastingAgency",
                table: "CastingAgentProfile",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Name of the casting agency the agent works for");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CastingAgentProfile",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Name of the casting agent");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CastingAgentProfile",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Foreign key to User");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ActorProfiles",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Actor profile unique identifier",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "ActorProfiles",
                type: "int",
                nullable: true,
                comment: "Age of the actor");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ActorProfiles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "First name of the actor");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ActorProfiles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "Last name of the actor");

            migrationBuilder.AddColumn<string>(
                name: "Portfolio",
                table: "ActorProfiles",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                comment: "Portfolio of the actor");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "ActorProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Url of the profile picture of the actor");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ActorProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Foreign key to User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorProfiles",
                table: "ActorProfiles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Casting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Casting unique identifier"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Casting title"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Description of the casting"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date the casting has been created"),
                    CastingEnd = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The day and time the casting ends"),
                    CastingAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Casting agent that has created the casting - foreign key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Casting_CastingAgentProfile_CastingAgentId",
                        column: x => x.CastingAgentId,
                        principalTable: "CastingAgentProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Movie unique identifier"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Movie title"),
                    Genre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Genre of the movie"),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Movie director name"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "Description of the movie"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Image URL of the movie")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Play",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Play unique identifier"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Play title"),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Play director name"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "Description of the play"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Image URL of the play")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Play", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActorCasting",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to ActorProfile"),
                    CastingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to Casting")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorCasting", x => new { x.ActorId, x.CastingId });
                    table.ForeignKey(
                        name: "FK_ActorCasting_ActorProfiles_ActorId",
                        column: x => x.ActorId,
                        principalTable: "ActorProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorCasting_Casting_CastingId",
                        column: x => x.CastingId,
                        principalTable: "Casting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to ActorProfile"),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to Movie")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorProfileId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ActorMovie_ActorProfiles_ActorProfileId",
                        column: x => x.ActorProfileId,
                        principalTable: "ActorProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorPlay",
                columns: table => new
                {
                    ActorProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to ActorProfile"),
                    PlayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to Play")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorPlay", x => new { x.ActorProfileId, x.PlayId });
                    table.ForeignKey(
                        name: "FK_ActorPlay_ActorProfiles_ActorProfileId",
                        column: x => x.ActorProfileId,
                        principalTable: "ActorProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorPlay_Play_PlayId",
                        column: x => x.PlayId,
                        principalTable: "Play",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastingAgentProfile_UserId",
                table: "CastingAgentProfile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActorProfiles_UserId",
                table: "ActorProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActorCasting_CastingId",
                table: "ActorCasting",
                column: "CastingId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MovieId",
                table: "ActorMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorPlay_PlayId",
                table: "ActorPlay",
                column: "PlayId");

            migrationBuilder.CreateIndex(
                name: "IX_Casting_CastingAgentId",
                table: "Casting",
                column: "CastingAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorProfiles_AspNetUsers_UserId",
                table: "ActorProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CastingAgentProfile_AspNetUsers_UserId",
                table: "CastingAgentProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorProfiles_AspNetUsers_UserId",
                table: "ActorProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_CastingAgentProfile_AspNetUsers_UserId",
                table: "CastingAgentProfile");

            migrationBuilder.DropTable(
                name: "ActorCasting");

            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropTable(
                name: "ActorPlay");

            migrationBuilder.DropTable(
                name: "Casting");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Play");

            migrationBuilder.DropIndex(
                name: "IX_CastingAgentProfile_UserId",
                table: "CastingAgentProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorProfiles",
                table: "ActorProfiles");

            migrationBuilder.DropIndex(
                name: "IX_ActorProfiles_UserId",
                table: "ActorProfiles");

            migrationBuilder.DropColumn(
                name: "CastingAgency",
                table: "CastingAgentProfile");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CastingAgentProfile");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CastingAgentProfile");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "ActorProfiles");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ActorProfiles");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ActorProfiles");

            migrationBuilder.DropColumn(
                name: "Portfolio",
                table: "ActorProfiles");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "ActorProfiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ActorProfiles");

            migrationBuilder.RenameTable(
                name: "ActorProfiles",
                newName: "ActorProfile");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CastingAgentProfile",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Casting agent profile unique identifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ActorProfile",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Actor profile unique identifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorProfile",
                table: "ActorProfile",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ActorProfileId",
                table: "AspNetUsers",
                column: "ActorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CastingAgentProfileId",
                table: "AspNetUsers",
                column: "CastingAgentProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ActorProfile_ActorProfileId",
                table: "AspNetUsers",
                column: "ActorProfileId",
                principalTable: "ActorProfile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CastingAgentProfile_CastingAgentProfileId",
                table: "AspNetUsers",
                column: "CastingAgentProfileId",
                principalTable: "CastingAgentProfile",
                principalColumn: "Id");
        }
    }
}
