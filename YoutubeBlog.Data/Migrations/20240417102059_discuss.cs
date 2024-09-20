using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoutubeBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class discuss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("200a7a09-1fa2-425b-9acf-84ddd8486868"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("b53eccf3-0462-4e64-b2e7-b3b99fd36088"));

            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("331a9afa-6fc5-4095-be90-7e7a39abe795"), new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"), "Asp.Net Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 17, 13, 20, 59, 386, DateTimeKind.Local).AddTicks(5652), null, null, new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"), 10 },
                    { new Guid("5341e9db-7d18-463f-a7f8-90a2010e5814"), new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 17, 13, 20, 59, 386, DateTimeKind.Local).AddTicks(5661), null, null, new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"), 10 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e165977-367f-4cf1-9a4b-31304bbb2154"),
                column: "ConcurrencyStamp",
                value: "f813fd0f-b140-4ee5-a5b5-ce4071a9c329");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("808544f8-cb21-4496-8dc2-55b640c2dac1"),
                column: "ConcurrencyStamp",
                value: "cf1f1ab8-4416-435d-840a-bc21bccc9540");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c940a422-3a97-4db4-a48a-beb06d5e1b02"),
                column: "ConcurrencyStamp",
                value: "8870726c-952a-4ec3-93ed-eb196ec640e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07f3cda3-e4e6-4eb2-a66e-1b680ad8e8c3", "AQAAAAEAACcQAAAAEE52VoHIij1xGfuAzguoRuaK6xFiiwg1oDxc7UxKEN71RdorEe1mClUey3Gtxp0QTg==", "6517ecf6-a68c-4499-8a71-ea401356d128" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35e62d68-2174-480b-a8e5-300b07b7aba0", "AQAAAAEAACcQAAAAEIiXM1HRnS9liFNOt2Ad1hjXBQw9FaYiSnkH4GLYxR6DTFRC9+oy2DxOqT1xxlFBgg==", "a56d1ae5-3f08-4f5e-96d4-68f5c22455ee" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 17, 13, 20, 59, 386, DateTimeKind.Local).AddTicks(7648));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 17, 13, 20, 59, 386, DateTimeKind.Local).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 17, 13, 20, 59, 386, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 17, 13, 20, 59, 386, DateTimeKind.Local).AddTicks(7782));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discussions");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("331a9afa-6fc5-4095-be90-7e7a39abe795"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("5341e9db-7d18-463f-a7f8-90a2010e5814"));

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
    }
}
