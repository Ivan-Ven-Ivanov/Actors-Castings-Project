using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorCasting_ActorProfiles_ActorId",
                table: "ActorCasting");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorCasting_Casting_CastingId",
                table: "ActorCasting");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_ActorProfiles_ActorProfileId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Movie_MovieId",
                table: "ActorMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorPlay_ActorProfiles_ActorProfileId",
                table: "ActorPlay");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorPlay_Play_PlayId",
                table: "ActorPlay");

            migrationBuilder.DropForeignKey(
                name: "FK_Casting_CastingAgentProfile_CastingAgentId",
                table: "Casting");

            migrationBuilder.DropForeignKey(
                name: "FK_CastingAgentProfile_AspNetUsers_UserId",
                table: "CastingAgentProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Play",
                table: "Play");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CastingAgentProfile",
                table: "CastingAgentProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Casting",
                table: "Casting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorPlay",
                table: "ActorPlay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorCasting",
                table: "ActorCasting");

            migrationBuilder.RenameTable(
                name: "Play",
                newName: "Plays");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.RenameTable(
                name: "CastingAgentProfile",
                newName: "CastingAgentProfiles");

            migrationBuilder.RenameTable(
                name: "Casting",
                newName: "Castings");

            migrationBuilder.RenameTable(
                name: "ActorPlay",
                newName: "ActorsPlays");

            migrationBuilder.RenameTable(
                name: "ActorMovie",
                newName: "ActorsMovies");

            migrationBuilder.RenameTable(
                name: "ActorCasting",
                newName: "ActorsCastings");

            migrationBuilder.RenameIndex(
                name: "IX_CastingAgentProfile_UserId",
                table: "CastingAgentProfiles",
                newName: "IX_CastingAgentProfiles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Casting_CastingAgentId",
                table: "Castings",
                newName: "IX_Castings_CastingAgentId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorPlay_PlayId",
                table: "ActorsPlays",
                newName: "IX_ActorsPlays_PlayId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovie_MovieId",
                table: "ActorsMovies",
                newName: "IX_ActorsMovies_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorCasting_CastingId",
                table: "ActorsCastings",
                newName: "IX_ActorsCastings_CastingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plays",
                table: "Plays",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CastingAgentProfiles",
                table: "CastingAgentProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Castings",
                table: "Castings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsPlays",
                table: "ActorsPlays",
                columns: new[] { "ActorProfileId", "PlayId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsMovies",
                table: "ActorsMovies",
                columns: new[] { "ActorProfileId", "MovieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorsCastings",
                table: "ActorsCastings",
                columns: new[] { "ActorId", "CastingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsCastings_ActorProfiles_ActorId",
                table: "ActorsCastings",
                column: "ActorId",
                principalTable: "ActorProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsCastings_Castings_CastingId",
                table: "ActorsCastings",
                column: "CastingId",
                principalTable: "Castings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsMovies_ActorProfiles_ActorProfileId",
                table: "ActorsMovies",
                column: "ActorProfileId",
                principalTable: "ActorProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsMovies_Movies_MovieId",
                table: "ActorsMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsPlays_ActorProfiles_ActorProfileId",
                table: "ActorsPlays",
                column: "ActorProfileId",
                principalTable: "ActorProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsPlays_Plays_PlayId",
                table: "ActorsPlays",
                column: "PlayId",
                principalTable: "Plays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CastingAgentProfiles_AspNetUsers_UserId",
                table: "CastingAgentProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Castings_CastingAgentProfiles_CastingAgentId",
                table: "Castings",
                column: "CastingAgentId",
                principalTable: "CastingAgentProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsCastings_ActorProfiles_ActorId",
                table: "ActorsCastings");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsCastings_Castings_CastingId",
                table: "ActorsCastings");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsMovies_ActorProfiles_ActorProfileId",
                table: "ActorsMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsMovies_Movies_MovieId",
                table: "ActorsMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsPlays_ActorProfiles_ActorProfileId",
                table: "ActorsPlays");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsPlays_Plays_PlayId",
                table: "ActorsPlays");

            migrationBuilder.DropForeignKey(
                name: "FK_CastingAgentProfiles_AspNetUsers_UserId",
                table: "CastingAgentProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Castings_CastingAgentProfiles_CastingAgentId",
                table: "Castings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plays",
                table: "Plays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Castings",
                table: "Castings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CastingAgentProfiles",
                table: "CastingAgentProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsPlays",
                table: "ActorsPlays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsMovies",
                table: "ActorsMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorsCastings",
                table: "ActorsCastings");

            migrationBuilder.RenameTable(
                name: "Plays",
                newName: "Play");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.RenameTable(
                name: "Castings",
                newName: "Casting");

            migrationBuilder.RenameTable(
                name: "CastingAgentProfiles",
                newName: "CastingAgentProfile");

            migrationBuilder.RenameTable(
                name: "ActorsPlays",
                newName: "ActorPlay");

            migrationBuilder.RenameTable(
                name: "ActorsMovies",
                newName: "ActorMovie");

            migrationBuilder.RenameTable(
                name: "ActorsCastings",
                newName: "ActorCasting");

            migrationBuilder.RenameIndex(
                name: "IX_Castings_CastingAgentId",
                table: "Casting",
                newName: "IX_Casting_CastingAgentId");

            migrationBuilder.RenameIndex(
                name: "IX_CastingAgentProfiles_UserId",
                table: "CastingAgentProfile",
                newName: "IX_CastingAgentProfile_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorsPlays_PlayId",
                table: "ActorPlay",
                newName: "IX_ActorPlay_PlayId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorsMovies_MovieId",
                table: "ActorMovie",
                newName: "IX_ActorMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorsCastings_CastingId",
                table: "ActorCasting",
                newName: "IX_ActorCasting_CastingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Play",
                table: "Play",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Casting",
                table: "Casting",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CastingAgentProfile",
                table: "CastingAgentProfile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorPlay",
                table: "ActorPlay",
                columns: new[] { "ActorProfileId", "PlayId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovie",
                table: "ActorMovie",
                columns: new[] { "ActorProfileId", "MovieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorCasting",
                table: "ActorCasting",
                columns: new[] { "ActorId", "CastingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorCasting_ActorProfiles_ActorId",
                table: "ActorCasting",
                column: "ActorId",
                principalTable: "ActorProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorCasting_Casting_CastingId",
                table: "ActorCasting",
                column: "CastingId",
                principalTable: "Casting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_ActorProfiles_ActorProfileId",
                table: "ActorMovie",
                column: "ActorProfileId",
                principalTable: "ActorProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Movie_MovieId",
                table: "ActorMovie",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorPlay_ActorProfiles_ActorProfileId",
                table: "ActorPlay",
                column: "ActorProfileId",
                principalTable: "ActorProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorPlay_Play_PlayId",
                table: "ActorPlay",
                column: "PlayId",
                principalTable: "Play",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Casting_CastingAgentProfile_CastingAgentId",
                table: "Casting",
                column: "CastingAgentId",
                principalTable: "CastingAgentProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CastingAgentProfile_AspNetUsers_UserId",
                table: "CastingAgentProfile",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
