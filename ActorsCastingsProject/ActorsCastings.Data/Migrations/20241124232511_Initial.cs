using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CastingAgentProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Movie unique identifier"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Movie title"),
                    Genre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Genre of the movie"),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Movie director name"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "Description of the movie"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Image URL of the movie"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Play unique identifier"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Play title"),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Play director name"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "Description of the play"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Image URL of the play"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Actor profile unique identifier"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "First name of the actor"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Last name of the actor"),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Url of the profile picture of the actor"),
                    Age = table.Column<int>(type: "int", nullable: true, comment: "Age of the actor"),
                    Portfolio = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Portfolio of the actor"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to User"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CastingAgents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Casting agent profile unique identifier"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Name of the casting agent"),
                    CastingAgency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Name of the casting agency the agent works for"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to User"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastingAgents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CastingAgents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorsMovies",
                columns: table => new
                {
                    ActorProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to ActorProfile"),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to Movie")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorsMovies", x => new { x.ActorProfileId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ActorsMovies_Actors_ActorProfileId",
                        column: x => x.ActorProfileId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorsMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorsPlays",
                columns: table => new
                {
                    ActorProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to ActorProfile"),
                    PlayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to Play")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorsPlays", x => new { x.ActorProfileId, x.PlayId });
                    table.ForeignKey(
                        name: "FK_ActorsPlays_Actors_ActorProfileId",
                        column: x => x.ActorProfileId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorsPlays_Plays_PlayId",
                        column: x => x.PlayId,
                        principalTable: "Plays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Castings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Casting unique identifier"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Casting title"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Description of the casting"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date the casting has been created"),
                    CastingEnd = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The day and time the casting ends"),
                    CastingAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Casting agent that has created the casting - foreign key"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Soft delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Castings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Castings_CastingAgents_CastingAgentId",
                        column: x => x.CastingAgentId,
                        principalTable: "CastingAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorsCastings",
                columns: table => new
                {
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to ActorProfile"),
                    CastingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to Casting")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorsCastings", x => new { x.ActorId, x.CastingId });
                    table.ForeignKey(
                        name: "FK_ActorsCastings_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ActorsCastings_Castings_CastingId",
                        column: x => x.CastingId,
                        principalTable: "Castings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_UserId",
                table: "Actors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActorsCastings_CastingId",
                table: "ActorsCastings",
                column: "CastingId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorsMovies_MovieId",
                table: "ActorsMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorsPlays_PlayId",
                table: "ActorsPlays",
                column: "PlayId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CastingAgents_UserId",
                table: "CastingAgents",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Castings_CastingAgentId",
                table: "Castings",
                column: "CastingAgentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorsCastings");

            migrationBuilder.DropTable(
                name: "ActorsMovies");

            migrationBuilder.DropTable(
                name: "ActorsPlays");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Castings");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Plays");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CastingAgents");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
