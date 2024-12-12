using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActorsCastings.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPhoneNumberToActors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Actors",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false,
                defaultValue: "",
                comment: "The phone number of the Actor");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("01bd7e28-6449-4efc-9f1f-f70a29caaac3"),
                column: "PhoneNumber",
                value: "+3223223");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("072212c8-bfb2-4179-802c-3cc46648bbdc"),
                column: "PhoneNumber",
                value: "012344222");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("0f6d3a0c-b710-4e8d-ae81-460396b39a91"),
                column: "PhoneNumber",
                value: "0004322");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("44c54c7a-b031-404c-afd6-830dd00e7b83"),
                column: "PhoneNumber",
                value: "000444222");

            migrationBuilder.UpdateData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("8141b06f-e8e8-4988-b317-c43665f74e8a"),
                column: "PhoneNumber",
                value: "011422");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00437133-5332-45a7-952e-dc8b6b740b76"),
                column: "ConcurrencyStamp",
                value: "116fa1da-db64-40ee-a41c-378272f5a8d0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a"),
                column: "ConcurrencyStamp",
                value: "d0b8271f-63c5-4ba1-8f63-d0edab16c948");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0719936f-703e-4836-ade1-1d00e7225256"),
                column: "ConcurrencyStamp",
                value: "9ed92faf-8101-4417-865f-b8f0aea746af");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634"),
                column: "ConcurrencyStamp",
                value: "f81e448a-d302-41e7-bb71-73a528f50eab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5faafe7-4729-4102-a2de-adf525f9d042"),
                column: "ConcurrencyStamp",
                value: "8cdf4fd1-a3cd-4af7-ad9e-71ef4b04436b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105"),
                column: "ConcurrencyStamp",
                value: "bfb5c078-c767-439f-b2c4-3c27b745d3ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241"),
                column: "ConcurrencyStamp",
                value: "f8f3db6c-9b8c-4b04-a1ce-3adab7b6861c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16"),
                column: "ConcurrencyStamp",
                value: "a41f7e2e-36bc-4cec-a565-1fae2c5e66b3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec"),
                column: "ConcurrencyStamp",
                value: "2ed70bf1-e34b-411b-8cac-a85001ca941c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157"),
                column: "ConcurrencyStamp",
                value: "dc5103a3-b9fc-40c1-a370-7bc303007d95");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Actors");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00437133-5332-45a7-952e-dc8b6b740b76"),
                column: "ConcurrencyStamp",
                value: "8bc6cd98-e87e-474b-8a87-3db809487bd7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0487d986-ece3-4f68-9e3a-2d064f15a14a"),
                column: "ConcurrencyStamp",
                value: "1eb726b5-6675-4e17-9942-282618442d44");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0719936f-703e-4836-ade1-1d00e7225256"),
                column: "ConcurrencyStamp",
                value: "815ad42e-9bfb-474e-ac54-0a41c672cd4f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("386f0ce1-1884-4c63-beb0-746bb8e73634"),
                column: "ConcurrencyStamp",
                value: "786faf26-823f-48ee-8255-2b6efc417c67");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5faafe7-4729-4102-a2de-adf525f9d042"),
                column: "ConcurrencyStamp",
                value: "1acb747b-de13-421f-b381-c07603e60a81");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be1c5570-a3dd-444a-9d43-bc0fef22a105"),
                column: "ConcurrencyStamp",
                value: "3300f8bd-6e70-4a95-96c7-451619330551");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c36656b1-d6c7-4682-92fd-2b5f5c982241"),
                column: "ConcurrencyStamp",
                value: "0cbc225b-adcf-4ec2-8596-1f74ec724c62");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e5aeebb4-3d1b-4c8b-b19e-1ea073938b16"),
                column: "ConcurrencyStamp",
                value: "8daa9673-b988-4a26-9299-3a209e085ce6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9e3fa9c-ff55-4788-9085-cd00806062ec"),
                column: "ConcurrencyStamp",
                value: "801421e6-3396-4f55-b2e6-247c75198b97");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efc80aaa-7890-4f3f-80c0-5a86b0afe157"),
                column: "ConcurrencyStamp",
                value: "9e2bbfbc-5f61-4beb-894a-895604f7cacb");
        }
    }
}
