using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReCrut.Infrastructure.SqlServer.EventDatabase.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueIdentifier", nullable: false),
                    AggregateId = table.Column<Guid>(type: "uniqueIdentifier", nullable: false),
                    AggregateName = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Datas = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_AggregateId",
                schema: "dbo",
                table: "Events",
                column: "AggregateId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AggregateId_AggregateName_Version",
                schema: "dbo",
                table: "Events",
                columns: new[] { "AggregateId", "AggregateName", "Version" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events",
                schema: "dbo");
        }
    }
}
