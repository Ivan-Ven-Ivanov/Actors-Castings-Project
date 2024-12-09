using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedUserNamePropertyInUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00437133-5332-45a7-952e-dc8b6b740b76"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "8bc6cd98-e87e-474b-8a87-3db809487bd7", "ivanivanov1@abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "1eb726b5-6675-4e17-9942-282618442d44", "ivanivanov8@abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0719936f-703e-4836-ade1-1d00e7225256"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "815ad42e-9bfb-474e-ac54-0a41c672cd4f", "ivanivanov3@abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "786faf26-823f-48ee-8255-2b6efc417c67", "ivanivanov6@abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5faafe7-4729-4102-a2de-adf525f9d042"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "1acb747b-de13-421f-b381-c07603e60a81", "ivanivanov10@abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "3300f8bd-6e70-4a95-96c7-451619330551", "ivanivanov4@abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "0cbc225b-adcf-4ec2-8596-1f74ec724c62", "ivanivanov5@abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "8daa9673-b988-4a26-9299-3a209e085ce6", "ivanivanov7@abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "801421e6-3396-4f55-b2e6-247c75198b97", "ivanivanov9@abv.bg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "9e2bbfbc-5f61-4beb-894a-895604f7cacb", "ivanivanov2@abv.bg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00437133-5332-45a7-952e-dc8b6b740b76"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "bf2fd981-09c0-424f-a9cc-225b2617f258", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "41f6fb0d-a8af-48d1-9566-427d1b3b3104", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0719936f-703e-4836-ade1-1d00e7225256"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "d8c76a8e-ad15-4bb2-b103-2e9d42b01b0f", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "ab76333d-5240-401e-9039-0f9cf9f0e653", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5faafe7-4729-4102-a2de-adf525f9d042"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "011eb19a-46f0-4f0e-9186-7ea0ede48ba5", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "a96a54a3-ecc4-4818-b0f7-c726e05f41cd", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "a2431fbd-1bf6-4e2a-bdd9-3542beb8f9e7", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "b66d73b3-f603-4402-a0b5-8bcbe23512e1", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "ec1a89db-c358-4beb-a244-2e43863d9d19", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157"),
                columns: new[] { "ConcurrencyStamp", "UserName" },
                values: new object[] { "7840f2c1-69fc-4788-b4a6-d7a9d9ceae78", null });
        }
    }
}
