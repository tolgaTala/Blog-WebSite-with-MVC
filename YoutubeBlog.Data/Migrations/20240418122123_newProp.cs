using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoutubeBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class newProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("76f8546a-18ff-464e-8850-1783f1d7c224"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f2e20bed-ff7e-4cc1-8ce5-392c22db428b"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("29796b31-8cf5-4876-8387-6d8b63769d6f"), new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"), "Asp.Net Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 18, 15, 21, 23, 95, DateTimeKind.Local).AddTicks(1679), null, null, new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"), 10 },
                    { new Guid("3ab0ac96-ccae-47e7-8d86-711555493f7b"), new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 18, 15, 21, 23, 95, DateTimeKind.Local).AddTicks(1697), null, null, new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"), 10 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e165977-367f-4cf1-9a4b-31304bbb2154"),
                column: "ConcurrencyStamp",
                value: "81d5fc20-0216-40a7-a2bb-a7f3e397388b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("808544f8-cb21-4496-8dc2-55b640c2dac1"),
                column: "ConcurrencyStamp",
                value: "7871f5a8-e6b2-4d16-95d3-7e6033d42ebb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c940a422-3a97-4db4-a48a-beb06d5e1b02"),
                column: "ConcurrencyStamp",
                value: "ae888ee3-5583-4b31-bb2d-ab7f1d6f5821");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dffd819b-c0ff-480e-aa00-695dafc41029", "AQAAAAEAACcQAAAAEA51S3/J8SvISRdNk9BGg/ZBu68CMRfuLNZpItZNRxDpKGSe9KI46r6yIyxgdQ8U/g==", "706abe2b-0a59-42cc-991a-baff9d64c58c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b81b80df-0c6e-4094-9b9e-ef25950358d0", "AQAAAAEAACcQAAAAEBVZD42cdGp7Ct3ba5eOQf4tZ/bvKADZgeuqberuDbcSTWuRgJ8o0phCmJuKmSyS6A==", "9081d908-28d5-4820-8d5c-e1b71f6cd75d" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 15, 21, 23, 95, DateTimeKind.Local).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 15, 21, 23, 95, DateTimeKind.Local).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 15, 21, 23, 95, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 15, 21, 23, 95, DateTimeKind.Local).AddTicks(3562));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("29796b31-8cf5-4876-8387-6d8b63769d6f"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3ab0ac96-ccae-47e7-8d86-711555493f7b"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("76f8546a-18ff-464e-8850-1783f1d7c224"), new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 18, 13, 9, 33, 529, DateTimeKind.Local).AddTicks(9344), null, null, new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"), 10 },
                    { new Guid("f2e20bed-ff7e-4cc1-8ce5-392c22db428b"), new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"), "Asp.Net Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 18, 13, 9, 33, 529, DateTimeKind.Local).AddTicks(9334), null, null, new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"), 10 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e165977-367f-4cf1-9a4b-31304bbb2154"),
                column: "ConcurrencyStamp",
                value: "8d1ce300-753d-4474-9612-b535be196554");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("808544f8-cb21-4496-8dc2-55b640c2dac1"),
                column: "ConcurrencyStamp",
                value: "34b8d1aa-3aee-4799-b157-0a22fbf53c6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c940a422-3a97-4db4-a48a-beb06d5e1b02"),
                column: "ConcurrencyStamp",
                value: "ac9194bf-4bfb-43e9-b95d-67a12e58dbaf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5afac30c-68b1-44f8-85a1-8d5003a0423a", "AQAAAAEAACcQAAAAEAtmp+U/2gqpmiJhPW+03In0grH8IhGCi3m9BqdbcZuiM9//wu+BGG3G9gFUWvS1Kw==", "4c748af9-f2a5-4b4c-adfb-e2d065337809" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ad1e136-c1e7-4799-8eae-d7432c877d62", "AQAAAAEAACcQAAAAEMOfZNrXFY+NqggTCBeMCzFHvIQUpTt3IvXsSMkzRiuWqtTT9n/kfvAiwTyzzJkyEg==", "38e86584-cb5e-4b68-a391-1e7d258a7056" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 13, 9, 33, 530, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 13, 9, 33, 530, DateTimeKind.Local).AddTicks(2404));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 13, 9, 33, 530, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 13, 9, 33, 530, DateTimeKind.Local).AddTicks(2595));
        }
    }
}
