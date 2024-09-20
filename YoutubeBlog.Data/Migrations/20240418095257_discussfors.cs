using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoutubeBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class discussfors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e4b386ff-597b-43c2-970d-c18af02ed510"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ed8027f6-5a73-428a-afb6-ddff12612d42"));

            migrationBuilder.CreateTable(
                name: "DiscussionFors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_DiscussionFors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("0a9b3486-2a64-4b4f-8db9-ddd194447750"), new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"), "Asp.Net Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 18, 12, 52, 57, 433, DateTimeKind.Local).AddTicks(856), null, null, new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"), 10 },
                    { new Guid("483bf5ab-6165-43d5-b8ab-7e270b40d385"), new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 18, 12, 52, 57, 433, DateTimeKind.Local).AddTicks(867), null, null, new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"), 10 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e165977-367f-4cf1-9a4b-31304bbb2154"),
                column: "ConcurrencyStamp",
                value: "62654521-7791-48b0-92fc-58e610e7e782");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("808544f8-cb21-4496-8dc2-55b640c2dac1"),
                column: "ConcurrencyStamp",
                value: "cfa8a9f6-d432-4c0c-88a4-10650355610c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c940a422-3a97-4db4-a48a-beb06d5e1b02"),
                column: "ConcurrencyStamp",
                value: "20a41649-0f0e-4bcf-9387-2af7855903a4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da21c575-1c37-4b65-84f5-70f132d1e3fb", "AQAAAAEAACcQAAAAEL9D7gpEOXftxVkTMVgKv8bNQpUxZWPIqvnBX2mydkeYa4kyHZkg/lNcz6ayFIHMLg==", "dfb5cb62-74b8-4985-b335-5d4947286394" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5aa8db6e-154b-47a2-9bd9-7e8827fcc958", "AQAAAAEAACcQAAAAEG7e5UgNpc6pd3zW6w2ZUhOKzpfnqEdVF64Oq5nuTyxZtu55mZZVXUBlEIT5JzKHGQ==", "fdd04582-bfad-484c-a169-04ed61d6a16c" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 12, 52, 57, 433, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 12, 52, 57, 433, DateTimeKind.Local).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 12, 52, 57, 433, DateTimeKind.Local).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 12, 52, 57, 433, DateTimeKind.Local).AddTicks(3890));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscussionFors");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("0a9b3486-2a64-4b4f-8db9-ddd194447750"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("483bf5ab-6165-43d5-b8ab-7e270b40d385"));

           

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("e4b386ff-597b-43c2-970d-c18af02ed510"), new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 18, 12, 49, 27, 785, DateTimeKind.Local).AddTicks(61), null, null, new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"), 10 },
                    { new Guid("ed8027f6-5a73-428a-afb6-ddff12612d42"), new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"), "Asp.Net Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Musa", new DateTime(2024, 4, 18, 12, 49, 27, 785, DateTimeKind.Local).AddTicks(52), null, null, new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"), 10 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e165977-367f-4cf1-9a4b-31304bbb2154"),
                column: "ConcurrencyStamp",
                value: "11414386-8aac-495b-b5af-219b5fc9429f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("808544f8-cb21-4496-8dc2-55b640c2dac1"),
                column: "ConcurrencyStamp",
                value: "e9650813-b10a-420a-8276-910569c3c153");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c940a422-3a97-4db4-a48a-beb06d5e1b02"),
                column: "ConcurrencyStamp",
                value: "b92188b3-b3cc-47bc-98f7-1490e0a4b88a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2605677d-ca5d-4077-b4cd-6a81ba84abf6", "AQAAAAEAACcQAAAAEH/tdGBkvZF2bF0ACJ/IzfUThDHMPSGT79XO/NF7cy+YCkBhrI+HvHXPZgcSlM4X1Q==", "a2119ae3-f891-4b32-b58b-dd4ab986ae26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60e693ac-fc10-4e8d-8a64-4488809eac13", "AQAAAAEAACcQAAAAEE6ppxGI1geu5/3tA3QkEkLc2u19C7I7MyvvXMJ0D9xKDMebyuOrBlhtpGc/IqzJyQ==", "f9956c48-cae4-479d-861e-6b8d87bcbeca" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 12, 49, 27, 785, DateTimeKind.Local).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 12, 49, 27, 785, DateTimeKind.Local).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 12, 49, 27, 785, DateTimeKind.Local).AddTicks(3161));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 4, 18, 12, 49, 27, 785, DateTimeKind.Local).AddTicks(3138));
        }
    }
}
