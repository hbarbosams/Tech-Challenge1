using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RegistrosRegiao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // DADOS REGIÃO
            migrationBuilder.Sql("INSERT INTO \"Regiao\" VALUES (default,'Norte');" +
                                 "INSERT INTO \"Regiao\" VALUES (default,'Sul');" +
                                 "INSERT INTO \"Regiao\" VALUES (default,'Sudeste');" +
                                 "INSERT INTO \"Regiao\" VALUES (default,'Centro-Oeste');" +
                                 "INSERT INTO \"Regiao\" VALUES (default,'Nordeste');"
                                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
