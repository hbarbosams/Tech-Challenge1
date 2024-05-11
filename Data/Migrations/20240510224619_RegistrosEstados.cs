using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RegistrosEstados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Estado\" VALUES (default, 'Acre', 'AC', 1);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Alagoas', 'AL', 5);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Amapá', 'AP', 1);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Amazonas', 'AM', 1);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Bahia', 'BA', 5);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Ceará', 'CE', 5);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Distrito Federal', 'DF', 4);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Espírito Santo', 'ES', 3);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Goiás', 'GO', 4);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Maranhão', 'MA', 5);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Mato Grosso', 'MT', 4);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Mato Grosso do Sul', 'MS', 4);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Minas Gerais', 'MG', 3);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Pará', 'PA', 1);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Paraíba', 'PB', 5);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Paraná', 'PR', 2);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Pernambuco', 'PE', 5);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Piauí', 'PI', 5);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Rio de Janeiro', 'RJ', 3);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Rio Grande do Norte', 'RN', 5);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Rio Grande do Sul', 'RS', 2);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Rondônia', 'RO', 1);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Roraima', 'RR', 1);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Santa Catarina', 'SC', 2);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'São Paulo', 'SP', 3);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Sergipe', 'SE', 5);" +
                                 "INSERT INTO \"Estado\" VALUES (default, 'Tocantins', 'TO', 1);"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
