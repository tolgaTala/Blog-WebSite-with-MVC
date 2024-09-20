using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoutubeBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class discussfors2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("21435a1e-f729-41af-80ab-79798f16d130"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("82ae4176-16d1-4673-93cf-7889c06c1e40"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("327fde24-6ba2-4809-9f15-12f1d89078b6"), new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"), "Asp.Net Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 18, 13, 9, 1, 425, DateTimeKind.Local).AddTicks(6142), null, null, new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"), 10 },
                    { new Guid("7fb8ba37-0608-41b3-b90b-d41fbaff65da"), new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 18, 13, 9, 1, 425, DateTimeKind.Local).AddTicks(6149), null, null, new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"), 10 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e165977-367f-4cf1-9a4b-31304bbb2154"),
                column: "ConcurrencyStamp",
                value: "56b9bc07-626c-49da-87cd-9d9fbba6ca1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("808544f8-cb21-4496-8dc2-55b640c2dac1"),
                column: "ConcurrencyStamp",
                value: "366bfa47-df0c-45d3-99c4-a8ed10e9bf27");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c940a422-3a97-4db4-a48a-beb06d5e1b02"),
                column: "ConcurrencyStamp",
                value: "f2c5933f-1eb1-4da7-83e7-0a568bccd140");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2c0a2dd-b0bc-4ca5-ab8e-19d1cfac8bac", "AQAAAAEAACcQAAAAELALu7bgmYVOkpPZ+jtSE+45LeN4bkWU7UBYesRyKgGSKLBuSordDpkRpvvhc5MwvQ==", "36b3b40c-a561-4a87-971d-119b839e5b2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6838b15-a45e-4e98-9306-41c9d8f11f9a", "AQAAAAEAACcQAAAAEOei1DlrnA+LXx2TCs5zgP5VRFqXCUbMFj9ef8XGb6od5XlTjpUOrEoW/AqiRUQ+qw==", "dd494c86-1864-49f5-8cdd-186115f65676" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 13, 9, 1, 425, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 13, 9, 1, 425, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 13, 9, 1, 425, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 13, 9, 1, 425, DateTimeKind.Local).AddTicks(8163));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("327fde24-6ba2-4809-9f15-12f1d89078b6"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("7fb8ba37-0608-41b3-b90b-d41fbaff65da"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("21435a1e-f729-41af-80ab-79798f16d130"), new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"), "Asp.Net Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 18, 12, 56, 50, 768, DateTimeKind.Local).AddTicks(8353), null, null, new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"), 10 },
                    { new Guid("82ae4176-16d1-4673-93cf-7889c06c1e40"), new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 18, 12, 56, 50, 768, DateTimeKind.Local).AddTicks(8363), null, null, new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"), 10 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e165977-367f-4cf1-9a4b-31304bbb2154"),
                column: "ConcurrencyStamp",
                value: "952df3b5-fed5-451f-9c36-b118844dcbb1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("808544f8-cb21-4496-8dc2-55b640c2dac1"),
                column: "ConcurrencyStamp",
                value: "a824568f-5591-48ad-8961-72a6c025f72a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c940a422-3a97-4db4-a48a-beb06d5e1b02"),
                column: "ConcurrencyStamp",
                value: "13b63609-b2aa-4677-8546-e46ff33fd1eb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bddf26a-4b14-4c53-8c6e-d00931d25619", "AQAAAAEAACcQAAAAEGvQPOXjKuB8KV2wnguf7b/TYbX/z/L4KqN3G8cGAs7EwA11YQOv/ok8ELr7ez5fUQ==", "14de328c-e765-4893-b316-a709e264e00b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19344224-b71c-4407-a415-a449de09cf26", "AQAAAAEAACcQAAAAEL3hKfHm3ffhDCBzB5+YbreeGVJuX300FvIWx9C3fXXRGAgoAq1hRWzGlaXxS8m0Vw==", "d7f89227-513d-4285-8b8f-136435a324d2" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 12, 56, 50, 769, DateTimeKind.Local).AddTicks(1171));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 12, 56, 50, 769, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 12, 56, 50, 769, DateTimeKind.Local).AddTicks(1389));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 12, 56, 50, 769, DateTimeKind.Local).AddTicks(1385));
        }
    }
}
