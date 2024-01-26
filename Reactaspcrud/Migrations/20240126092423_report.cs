using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reactaspcrud.Migrations
{
    /// <inheritdoc />
    public partial class report : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AccionesInmediatas = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Antecedentes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AtencionAlEvento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PersonalInvolucrado = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Impacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");
        }
    }
}
