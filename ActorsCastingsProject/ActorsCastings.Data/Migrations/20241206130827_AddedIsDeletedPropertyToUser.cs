using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsDeletedPropertyToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00437133-5332-45a7-952e-dc8b6b740b76"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted" },
                values: new object[] { "60208f15-acdb-40fa-8b44-220340e1a5b3", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted" },
                values: new object[] { "a1029caa-bebb-4b53-9a0f-84d1e73799e6", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0719936f-703e-4836-ade1-1d00e7225256"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted" },
                values: new object[] { "0e37fac3-df9a-4c5f-b24d-5f25786b0357", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted" },
                values: new object[] { "deaae663-c417-4016-b469-483910947738", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5faafe7-4729-4102-a2de-adf525f9d042"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted" },
                values: new object[] { "ef51024c-ae5a-4d3b-8ac6-4a9f5b9f5bbc", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted" },
                values: new object[] { "3fa45a6d-6e59-400a-a1a3-c9d24c1f9b90", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted" },
                values: new object[] { "a6cd628b-7929-4696-a780-b529905f5b1b", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted" },
                values: new object[] { "cbd0ab6f-94a9-46a7-a3d7-9179b46985a0", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted" },
                values: new object[] { "72df934a-e522-4664-806c-9e4d22265fd3", false });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157"),
                columns: new[] { "ConcurrencyStamp", "IsDeleted" },
                values: new object[] { "c7915a00-4259-4a74-818d-ac08c0e85cbf", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00437133-5332-45a7-952e-dc8b6b740b76"),
                column: "ConcurrencyStamp",
                value: "a5b1742c-850a-4a8a-b18e-07d3113ecb59");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a"),
                column: "ConcurrencyStamp",
                value: "5aabd106-e3e3-4a38-9bf3-5adca6a766ee");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0719936f-703e-4836-ade1-1d00e7225256"),
                column: "ConcurrencyStamp",
                value: "ff030458-ded6-41aa-9742-9f2a8fc0ad63");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634"),
                column: "ConcurrencyStamp",
                value: "766ca146-edb7-43e4-89a0-70eaa368aebf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5faafe7-4729-4102-a2de-adf525f9d042"),
                column: "ConcurrencyStamp",
                value: "0584c84a-4faa-4a48-b698-0ce4121b16f3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105"),
                column: "ConcurrencyStamp",
                value: "03b4026e-4b01-4b5e-b1d7-146bdf56840b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241"),
                column: "ConcurrencyStamp",
                value: "26425d54-cd17-4a1b-8c93-ea253d83ab70");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16"),
                column: "ConcurrencyStamp",
                value: "e7ac27ec-252e-4749-a424-017234c08033");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec"),
                column: "ConcurrencyStamp",
                value: "d9072495-1883-4d4e-b779-cda0149d86d3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157"),
                column: "ConcurrencyStamp",
                value: "3259adaa-f615-4b78-a552-e7c7f1202e5b");
        }
    }
}
