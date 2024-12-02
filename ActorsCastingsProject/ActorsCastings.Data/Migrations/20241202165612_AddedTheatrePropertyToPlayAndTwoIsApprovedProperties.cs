using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTheatrePropertyToPlayAndTwoIsApprovedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Theatre",
                table: "Plays",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "The theatre where the play is played");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "ActorsPlays",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the part of the actor in the play approved by Admin");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "ActorsMovies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the part of the actor in the movie approved by Admin");

            migrationBuilder.UpdateData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("0276d235-774d-441f-ac77-9badafc4d814") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("688dec9c-6a78-4769-80cc-b2281c4c7d2a") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("d5aa5fca-551e-4721-a332-b56a5821dd73") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), new Guid("688dec9c-6a78-4769-80cc-b2281c4c7d2a") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), new Guid("7f3c4a10-2f6f-4434-840b-73f135c83aca") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), new Guid("0276d235-774d-441f-ac77-9badafc4d814") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), new Guid("688dec9c-6a78-4769-80cc-b2281c4c7d2a") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), new Guid("7f3c4a10-2f6f-4434-840b-73f135c83aca") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("44c54c7a-b031-404c-afd6-830dd00e7b83"), new Guid("0276d235-774d-441f-ac77-9badafc4d814") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsMovies",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { new Guid("8141b06f-e8e8-4988-b317-c43665f74e8a"), new Guid("cbe7da20-087d-4f57-bd21-9b9af1690bc1") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("099134cb-ae73-4199-927c-9f84e1064710") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"), new Guid("9abd46e4-9f75-41a9-8cc3-d142997c04cf") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), new Guid("099134cb-ae73-4199-927c-9f84e1064710") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"), new Guid("cef3172a-d9ae-41c7-834f-cd934a506b95") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"), new Guid("9abd46e4-9f75-41a9-8cc3-d142997c04cf") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("44c54c7a-b031-404c-afd6-830dd00e7b83"), new Guid("253a0612-1359-4c37-a6b2-75593ea3320e") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("44c54c7a-b031-404c-afd6-830dd00e7b83"), new Guid("cef3172a-d9ae-41c7-834f-cd934a506b95") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ActorsPlays",
                keyColumns: new[] { "ActorId", "PlayId" },
                keyValues: new object[] { new Guid("8141b06f-e8e8-4988-b317-c43665f74e8a"), new Guid("099134cb-ae73-4199-927c-9f84e1064710") },
                column: "IsApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00437133-5332-45a7-952e-dc8b6b740b76"),
                column: "ConcurrencyStamp",
                value: "51dd7b8b-dcd1-4aa3-ba3f-e863d3d3c873");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a"),
                column: "ConcurrencyStamp",
                value: "bc4ac699-bb29-40e7-8c4a-3d90ebfa86a1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0719936f-703e-4836-ade1-1d00e7225256"),
                column: "ConcurrencyStamp",
                value: "01110260-6b2f-49f0-9f83-f04b03d3114a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634"),
                column: "ConcurrencyStamp",
                value: "27841128-8156-4a03-a52b-0b8327d35ce3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5faafe7-4729-4102-a2de-adf525f9d042"),
                column: "ConcurrencyStamp",
                value: "f4194cd5-f1d4-47a3-aaa9-91d36df4046e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105"),
                column: "ConcurrencyStamp",
                value: "8e493e64-7fd7-498b-8670-23688ff07c90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241"),
                column: "ConcurrencyStamp",
                value: "260da7e4-a32e-4f4f-9684-1dfcddde323f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16"),
                column: "ConcurrencyStamp",
                value: "2f123e66-9e2b-40a5-82b3-bad3e7341b36");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec"),
                column: "ConcurrencyStamp",
                value: "28827ce3-ce73-4c20-9499-9c51eed50405");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157"),
                column: "ConcurrencyStamp",
                value: "908d446a-2b42-4ddc-8cf6-f9bf8ccaee06");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("099134cb-ae73-4199-927c-9f84e1064710"),
                column: "Theatre",
                value: "National Theatre Ivan Vazov");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("253a0612-1359-4c37-a6b2-75593ea3320e"),
                column: "Theatre",
                value: "National Theatre Ivan Vazov");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("9abd46e4-9f75-41a9-8cc3-d142997c04cf"),
                column: "Theatre",
                value: "Artvent Theatre");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("cef3172a-d9ae-41c7-834f-cd934a506b95"),
                column: "Theatre",
                value: "National Theatre Ivan Vazov");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("d49574dd-ab22-4b5c-9de6-892c09e786f3"),
                column: "Theatre",
                value: "National Theatre Ivan Vazov");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theatre",
                table: "Plays");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "ActorsPlays");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "ActorsMovies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00437133-5332-45a7-952e-dc8b6b740b76"),
                column: "ConcurrencyStamp",
                value: "b82b7a04-c41d-49bd-a7f3-0fff5cde8fc1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a"),
                column: "ConcurrencyStamp",
                value: "36ccc4a7-8862-4e10-8ee3-9b94d1f97da4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0719936f-703e-4836-ade1-1d00e7225256"),
                column: "ConcurrencyStamp",
                value: "4d7bbf4d-10ab-4f87-9b8d-c723b0b3f0a4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634"),
                column: "ConcurrencyStamp",
                value: "519a02bc-57e4-4e00-9299-6138ebae9dce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5faafe7-4729-4102-a2de-adf525f9d042"),
                column: "ConcurrencyStamp",
                value: "7d40e4cd-e0f3-4485-8eb3-0be4cdde9ca5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105"),
                column: "ConcurrencyStamp",
                value: "e3ac478a-36e2-447d-8426-b1f8f9ae041f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241"),
                column: "ConcurrencyStamp",
                value: "1ec680d0-df38-47a3-9a4b-a50ab74a3679");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16"),
                column: "ConcurrencyStamp",
                value: "f0b1c98b-3757-4213-a132-3a2284444998");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec"),
                column: "ConcurrencyStamp",
                value: "2511739e-682b-4257-8fb5-1cb51d653399");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157"),
                column: "ConcurrencyStamp",
                value: "a3c77169-0318-499c-aee0-3d5cac0a7696");
        }
    }
}
