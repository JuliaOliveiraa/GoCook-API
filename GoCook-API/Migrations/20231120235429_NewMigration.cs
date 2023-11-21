using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoCook_API.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Cd_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nm_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ds_Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Cd_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Cd_Receita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nm_Receita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qt_TempoPreparo = table.Column<int>(type: "int", nullable: false),
                    Ds_ModoPreparo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qt_PessoasServidas = table.Column<int>(type: "int", nullable: false),
                    Cd_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Cd_Receita);
                    table.ForeignKey(
                        name: "FK_Receitas_Usuarios_Cd_Usuario",
                        column: x => x.Cd_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Cd_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Cd_Ingrediente = table.Column<int>(type: "int", nullable: false),
                    Cd_Receita = table.Column<int>(type: "int", nullable: false),
                    Nm_Ingrediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qt_Ingrediente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => new { x.Cd_Ingrediente, x.Cd_Receita });
                    table.ForeignKey(
                        name: "FK_Ingredientes_Receitas_Cd_Receita",
                        column: x => x.Cd_Receita,
                        principalTable: "Receitas",
                        principalColumn: "Cd_Receita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_Cd_Receita",
                table: "Ingredientes",
                column: "Cd_Receita");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_Cd_Usuario",
                table: "Receitas",
                column: "Cd_Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
