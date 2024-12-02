using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ML_personalizacion.Migrations
{
    /// <inheritdoc />
    public partial class version1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ML_personas",
                columns: table => new
                {
                    ML_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ML_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ML_apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ML_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ML_telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ML_personas", x => x.ML_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ML_personas");
        }
    }
}
