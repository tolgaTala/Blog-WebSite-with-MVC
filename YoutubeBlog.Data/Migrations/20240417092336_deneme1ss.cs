using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoutubeBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class deneme1ss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9cfc4172-9c6d-4263-8647-a96575746ddc"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("cc33493f-2db0-4ceb-a5ba-c79d82b176c2"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("200a7a09-1fa2-425b-9acf-84ddd8486868"), new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"), "Asp.Net Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 17, 12, 23, 35, 961, DateTimeKind.Local).AddTicks(1590), null, null, new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"), 10 },
                    { new Guid("b53eccf3-0462-4e64-b2e7-b3b99fd36088"), new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 17, 12, 23, 35, 961, DateTimeKind.Local).AddTicks(1601), null, null, new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"), 10 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e165977-367f-4cf1-9a4b-31304bbb2154"),
                column: "ConcurrencyStamp",
                value: "ab50130b-3b91-4ef9-b78a-7ee5a59e36ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("808544f8-cb21-4496-8dc2-55b640c2dac1"),
                column: "ConcurrencyStamp",
                value: "e3e59113-baf4-44b1-9676-4696fb27e576");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c940a422-3a97-4db4-a48a-beb06d5e1b02"),
                column: "ConcurrencyStamp",
                value: "4784809c-9631-4d76-9d09-9776d8248a04");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70a697b6-783c-4683-827a-82e80ce4f6c9", "AQAAAAEAACcQAAAAEKdT6JkA7LZ/jAmyvLbtwx+QvHDu+9wpAxRGlgVb3/hyAsJqsbUGxRfVhCQJ9nBDyg==", "ac2a0d6c-95af-44aa-a8e2-5e55b7580d4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c12f715b-4b62-4f17-b370-e6ea8dad1311", "AQAAAAEAACcQAAAAEP7N7sR3piU9u0vCdtqTfvt7OsGXphUHl+iAbW9ipqAffe12KylBAzmqfudIeMo/Zg==", "f60e2509-cc56-43f4-a94e-667e1357724a" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 17, 12, 23, 35, 961, DateTimeKind.Local).AddTicks(4437));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 17, 12, 23, 35, 961, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 17, 12, 23, 35, 961, DateTimeKind.Local).AddTicks(4618));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 17, 12, 23, 35, 961, DateTimeKind.Local).AddTicks(4613));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("200a7a09-1fa2-425b-9acf-84ddd8486868"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("b53eccf3-0462-4e64-b2e7-b3b99fd36088"));

            

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("9cfc4172-9c6d-4263-8647-a96575746ddc"), new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 17, 12, 20, 47, 527, DateTimeKind.Local).AddTicks(8180), null, null, new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"), 10 },
                    { new Guid("cc33493f-2db0-4ceb-a5ba-c79d82b176c2"), new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"), "Asp.Net Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 17, 12, 20, 47, 527, DateTimeKind.Local).AddTicks(8170), null, null, new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"), 10 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e165977-367f-4cf1-9a4b-31304bbb2154"),
                column: "ConcurrencyStamp",
                value: "c051f5f8-9510-43db-b024-7c8207aadc7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("808544f8-cb21-4496-8dc2-55b640c2dac1"),
                column: "ConcurrencyStamp",
                value: "c3b8a255-5be0-4ba1-a4b8-24bbe82e65a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c940a422-3a97-4db4-a48a-beb06d5e1b02"),
                column: "ConcurrencyStamp",
                value: "1430d57a-2a92-4efc-86b0-ddfa0825d508");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e94a915b-1b6c-472f-9754-fba736551a95", "AQAAAAEAACcQAAAAEEcIVSKTta2Obt8P9+A9vHBFVv2S3fdlW6nPfb/ANcPksBAEonXihkgq1eTHg0DKWQ==", "5c534712-0c2c-491c-8459-3f415ad9eced" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6cf3ae4-c358-460b-9b6e-b94840b4d517", "AQAAAAEAACcQAAAAEEjxTKO8q0Z1AFMWHvatJeljA7kxDJFZdnvTv1XbivN1bMp9VznIwjpcQTVYDD5yJg==", "e59468f3-cf35-4e5a-965f-d7a3f9a149a6" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 17, 12, 20, 47, 528, DateTimeKind.Local).AddTicks(884));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 17, 12, 20, 47, 528, DateTimeKind.Local).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 17, 12, 20, 47, 528, DateTimeKind.Local).AddTicks(1057));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 17, 12, 20, 47, 528, DateTimeKind.Local).AddTicks(1052));

           }
    }
}
