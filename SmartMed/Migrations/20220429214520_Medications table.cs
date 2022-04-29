using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMed.Migrations
{
    public partial class Medicationstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "CreationDate", "Name", "Quantity", "UniqueId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 29, 22, 45, 20, 686, DateTimeKind.Local).AddTicks(5671), "Ibuprofeno", 3, new Guid("040f6c87-46f3-4273-a074-c7c263df3795") },
                    { 2, new DateTime(2022, 4, 29, 22, 45, 20, 686, DateTimeKind.Local).AddTicks(5720), "Paracetemol", 5, new Guid("416e39ba-f610-4bc9-8aae-01cc676868fd") },
                    { 3, new DateTime(2022, 4, 29, 22, 45, 20, 686, DateTimeKind.Local).AddTicks(5724), "Aspirina", 2, new Guid("52bcc397-5936-417a-88d1-695807bc9524") },
                    { 4, new DateTime(2022, 4, 29, 22, 45, 20, 686, DateTimeKind.Local).AddTicks(5727), "Tramadol", 1, new Guid("4c90a9e0-b18c-4049-8bcc-b59c54fe70e9") },
                    { 5, new DateTime(2022, 4, 29, 22, 45, 20, 686, DateTimeKind.Local).AddTicks(5730), "Codeína", 10, new Guid("d8aa141f-84f7-474d-92f0-c5eebdea8606") },
                    { 6, new DateTime(2022, 4, 29, 22, 45, 20, 686, DateTimeKind.Local).AddTicks(5733), "Metamizol", 5, new Guid("33b35c53-2620-4756-bab9-3b390df80069") },
                    { 7, new DateTime(2022, 4, 29, 22, 45, 20, 686, DateTimeKind.Local).AddTicks(5736), "Gabapentina", 3, new Guid("7fc471ac-b16a-4166-90a1-ff13a56a47df") },
                    { 8, new DateTime(2022, 4, 29, 22, 45, 20, 686, DateTimeKind.Local).AddTicks(5739), "Daflon", 20, new Guid("efdab810-1d77-4906-9464-05475d7231a5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medications_UniqueId",
                table: "Medications",
                column: "UniqueId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medications");
        }
    }
}
