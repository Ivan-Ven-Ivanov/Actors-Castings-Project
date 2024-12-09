using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSecurityStampToUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00437133-5332-45a7-952e-dc8b6b740b76"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bf2fd981-09c0-424f-a9cc-225b2617f258", "217138eb-144c-49bc-b76d-42c61ec89fec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "41f6fb0d-a8af-48d1-9566-427d1b3b3104", "f7fd6461-0a77-47ca-96a3-f10a05100b0a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0719936f-703e-4836-ade1-1d00e7225256"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d8c76a8e-ad15-4bb2-b103-2e9d42b01b0f", "9a6f1233-3142-4720-878e-7192a4ae1cbc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ab76333d-5240-401e-9039-0f9cf9f0e653", "37ae8571-b3d6-4e35-bb2c-c66f5df37592" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5faafe7-4729-4102-a2de-adf525f9d042"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "011eb19a-46f0-4f0e-9186-7ea0ede48ba5", "31d04655-d49f-45b2-adf5-88131c6589c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a96a54a3-ecc4-4818-b0f7-c726e05f41cd", "bf3fef4f-b428-42ee-9e53-e6cc3f66409b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a2431fbd-1bf6-4e2a-bdd9-3542beb8f9e7", "645ca1c0-e9a2-4acc-98bf-a2235ea3a27b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b66d73b3-f603-4402-a0b5-8bcbe23512e1", "d1391658-0b75-4b97-b7f9-e8cda1d658fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ec1a89db-c358-4beb-a244-2e43863d9d19", "77fc4f2f-5d60-4ac7-927a-f45f03849e21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7840f2c1-69fc-4788-b4a6-d7a9d9ceae78", "d0860d2b-1212-420b-baf1-e448c996cf90" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00437133-5332-45a7-952e-dc8b6b740b76"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "60208f15-acdb-40fa-8b44-220340e1a5b3", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a1029caa-bebb-4b53-9a0f-84d1e73799e6", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0719936f-703e-4836-ade1-1d00e7225256"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0e37fac3-df9a-4c5f-b24d-5f25786b0357", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "deaae663-c417-4016-b469-483910947738", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5faafe7-4729-4102-a2de-adf525f9d042"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ef51024c-ae5a-4d3b-8ac6-4a9f5b9f5bbc", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3fa45a6d-6e59-400a-a1a3-c9d24c1f9b90", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a6cd628b-7929-4696-a780-b529905f5b1b", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cbd0ab6f-94a9-46a7-a3d7-9179b46985a0", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "72df934a-e522-4664-806c-9e4d22265fd3", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c7915a00-4259-4a74-818d-ac08c0e85cbf", null });
        }
    }
}
