using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReCrut.Infrastructure.SqlServer.ProjectionDatabase.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Candidats",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueIdentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    Trigramme = table.Column<string>(type: "nvarchar(512)", nullable: false),
                    DatePriseContact = table.Column<DateTime>(type: "datetime", nullable: false),
                    CandidatStatus = table.Column<string>(type: "nvarchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidats", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidats",
                schema: "dbo");
        }
    }
}
