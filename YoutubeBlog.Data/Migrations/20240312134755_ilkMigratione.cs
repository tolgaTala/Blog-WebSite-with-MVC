using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YoutubeBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class ilkMigratione : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaturaDetails");

            migrationBuilder.DropTable(
                name: "FaturaInfos");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8169df34-9b90-4fd5-a5e1-e1d37e518517"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("96b75ef6-5e6d-4e40-8bd5-5cdb1c8fb3a0"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("1937be54-55a9-42ff-89d5-1512263c6d5d"), new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"), "Asp.Net Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Tolga", new DateTime(2024, 3, 12, 16, 47, 55, 503, DateTimeKind.Local).AddTicks(3102), null, null, new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"), 10 },
                    { new Guid("27334c96-ec2f-461f-8778-e58da56128f8"), new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Tolga", new DateTime(2024, 3, 12, 16, 47, 55, 503, DateTimeKind.Local).AddTicks(3109), null, null, new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"), 10 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e165977-367f-4cf1-9a4b-31304bbb2154"),
                column: "ConcurrencyStamp",
                value: "24d7c07d-a05d-4d9b-adaf-7e79d9a46127");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("808544f8-cb21-4496-8dc2-55b640c2dac1"),
                column: "ConcurrencyStamp",
                value: "6827eed5-87c3-4238-aa52-b4210285a0ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c940a422-3a97-4db4-a48a-beb06d5e1b02"),
                column: "ConcurrencyStamp",
                value: "878761b6-6644-4406-a00c-211694624df7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ffe9215-2148-40c3-99f2-6213b6fc4f0a", "AQAAAAEAACcQAAAAEB2V6t02K7GPwcoiikiJLthq92sM/JTS2eR/wI9SnWw5zO9CetThiTL+/1oXOVQTOA==", "f51df58c-8c11-4336-8fdf-fd3936975999" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76b948c9-61b0-4ed8-9b87-64a341c7ff4b", "AQAAAAEAACcQAAAAELv75RvHEJoUZPdoS4P6525EhMGiTciYCiIlx7jI7j89KwEqLhddxWUQyvUMSpoDfg==", "62a11b6c-3125-4c1e-9ce5-516c5874b093" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 12, 16, 47, 55, 503, DateTimeKind.Local).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 12, 16, 47, 55, 503, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 12, 16, 47, 55, 503, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 12, 16, 47, 55, 503, DateTimeKind.Local).AddTicks(5295));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1937be54-55a9-42ff-89d5-1512263c6d5d"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("27334c96-ec2f-461f-8778-e58da56128f8"));

            migrationBuilder.CreateTable(
                name: "FaturaInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FaturaNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Kimden = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaturaDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FaturaInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Birimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaturaDetails_FaturaInfos_FaturaInfoId",
                        column: x => x.FaturaInfoId,
                        principalTable: "FaturaInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("8169df34-9b90-4fd5-a5e1-e1d37e518517"), new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"), "Visual Studio Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Tolga", new DateTime(2024, 2, 6, 17, 2, 54, 118, DateTimeKind.Local).AddTicks(3304), null, null, new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"), false, null, null, "Visual Studio Deneme Makalesi 1", new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"), 10 },
                    { new Guid("96b75ef6-5e6d-4e40-8bd5-5cdb1c8fb3a0"), new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"), "Asp.Net Core Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Tolga", new DateTime(2024, 2, 6, 17, 2, 54, 118, DateTimeKind.Local).AddTicks(3279), null, null, new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"), false, null, null, "Asp.Net Core Deneme Makalesi 1", new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"), 10 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e165977-367f-4cf1-9a4b-31304bbb2154"),
                column: "ConcurrencyStamp",
                value: "70216ef5-ca82-4593-bba4-8aa1ab6c66fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("808544f8-cb21-4496-8dc2-55b640c2dac1"),
                column: "ConcurrencyStamp",
                value: "a63416ec-109b-4146-aae8-8b8805c6440f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c940a422-3a97-4db4-a48a-beb06d5e1b02"),
                column: "ConcurrencyStamp",
                value: "daf2ef33-0124-46c7-b355-c06dcff19c87");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d29d4237-d4e1-4fd9-94ba-0195ad4676ed"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7986fc1-36d1-4406-a26c-5f2434f69a84", "AQAAAAEAACcQAAAAEKbVMdWDxRkMlnW3IrVzqz4yMTDaMKxO0YypsSAXi1KBSX46+jjPnccU7LmLupSjFw==", "5c0c6be7-a4fb-46fb-82c1-87b199cd39ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4feb138-6af3-4017-b511-fa9662f062f7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77717390-89db-4402-b6ab-39015748ddf6", "AQAAAAEAACcQAAAAEKVLfJnBOpM3XEBiBoyQeyvOXfvILIoqx+NarApGCZuMJ24pajF8Cb9vuDZn2hRfUQ==", "332fe502-fa9b-4f88-a129-e8e3773be3fb" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5875664c-4a6f-463d-8032-230a83bdb5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 17, 2, 54, 118, DateTimeKind.Local).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaad017e-8f3a-4453-8000-f2c7c09b20a3"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 17, 2, 54, 118, DateTimeKind.Local).AddTicks(6027));

            migrationBuilder.InsertData(
                table: "FaturaInfos",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FaturaNo", "IsDeleted", "Kimden", "ModifiedBy", "ModifiedDate", "Tarih", "ToplamTutar" },
                values: new object[] { new Guid("ccb8c581-ea68-47a4-9945-82bd5cbd49a5"), "undefined", new DateTime(2024, 2, 6, 17, 2, 54, 118, DateTimeKind.Local).AddTicks(6495), null, null, "123456", false, "Dünyam Pet", null, null, new DateTime(2024, 2, 6, 17, 2, 54, 118, DateTimeKind.Local).AddTicks(6499), 2000m });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("30e70875-a0a8-466d-937b-8b325e11b5bb"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 17, 2, 54, 118, DateTimeKind.Local).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("cb2150f3-a4f9-4316-b1c1-a4fe1693fc7e"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 6, 17, 2, 54, 118, DateTimeKind.Local).AddTicks(6634));

            migrationBuilder.InsertData(
                table: "FaturaDetails",
                columns: new[] { "Id", "Adet", "Birimi", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FaturaInfoId", "Fiyat", "IsDeleted", "ModifiedBy", "ModifiedDate", "ToplamTutar", "UrunAdi" },
                values: new object[,]
                {
                    { new Guid("19169178-6f46-4bae-9e3d-22a84976e571"), 2, "Kg", "undefined", new DateTime(2024, 2, 6, 17, 2, 54, 118, DateTimeKind.Local).AddTicks(6344), null, null, new Guid("ccb8c581-ea68-47a4-9945-82bd5cbd49a5"), 700m, false, null, null, 1400m, "Mito" },
                    { new Guid("bb5d7772-4246-4952-a5a7-b4a03c1e828e"), 2, "Kg", "undefined", new DateTime(2024, 2, 6, 17, 2, 54, 118, DateTimeKind.Local).AddTicks(6353), null, null, new Guid("ccb8c581-ea68-47a4-9945-82bd5cbd49a5"), 750m, false, null, null, 1500m, "Mito Mix" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaturaDetails_FaturaInfoId",
                table: "FaturaDetails",
                column: "FaturaInfoId");
        }
    }
}
