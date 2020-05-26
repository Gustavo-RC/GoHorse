using Microsoft.EntityFrameworkCore.Migrations;

namespace GoHorseDAL.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viagens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeiculoId = table.Column<int>(nullable: true),
                    AnimalId = table.Column<int>(nullable: true),
                    DataOrigem = table.Column<string>(nullable: true),
                    DataDestino = table.Column<string>(nullable: true),
                    ValorViagem = table.Column<double>(nullable: false),
                    EnderecoOrigemEnderecoId = table.Column<int>(nullable: true),
                    EnderecoDestinoEnderecoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: true),
                    NumeroParada = table.Column<int>(nullable: true),
                    ViagemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Viagens_ViagemId",
                        column: x => x.ViagemId,
                        principalTable: "Viagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EnderecoId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: true),
                    Motorista_Id = table.Column<int>(nullable: true),
                    NRegistroCnh = table.Column<string>(nullable: true),
                    ValidadeCnh = table.Column<string>(nullable: true),
                    CategoriaCnh = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_Pessoas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NRegistro = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Raca = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    ClientePessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animais_Pessoas_ClientePessoaId",
                        column: x => x.ClientePessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    NCartao = table.Column<string>(nullable: true),
                    Validade = table.Column<string>(nullable: true),
                    Cv = table.Column<int>(nullable: false),
                    ClientePessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartoes_Pessoas_ClientePessoaId",
                        column: x => x.ClientePessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotoristaPessoaId = table.Column<int>(nullable: true),
                    Agencia = table.Column<string>(nullable: true),
                    NConta = table.Column<string>(nullable: true),
                    Banco = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Pessoas_MotoristaPessoaId",
                        column: x => x.MotoristaPessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PessoaId = table.Column<int>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefones_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotoristaPessoaId = table.Column<int>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    AnoFabricacao = table.Column<string>(nullable: true),
                    Placa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Pessoas_MotoristaPessoaId",
                        column: x => x.MotoristaPessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViagemId = table.Column<int>(nullable: true),
                    CartaoId = table.Column<int>(nullable: true),
                    ContaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Cartoes_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Viagens_ViagemId",
                        column: x => x.ViagemId,
                        principalTable: "Viagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animais_ClientePessoaId",
                table: "Animais",
                column: "ClientePessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_ClientePessoaId",
                table: "Cartoes",
                column: "ClientePessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_MotoristaPessoaId",
                table: "Contas",
                column: "MotoristaPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ViagemId",
                table: "Enderecos",
                column: "ViagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_CartaoId",
                table: "Pagamentos",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_ContaId",
                table: "Pagamentos",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_ViagemId",
                table: "Pagamentos",
                column: "ViagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_PessoaId",
                table: "Telefones",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_MotoristaPessoaId",
                table: "Veiculos",
                column: "MotoristaPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_AnimalId",
                table: "Viagens",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_EnderecoDestinoEnderecoId",
                table: "Viagens",
                column: "EnderecoDestinoEnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_EnderecoOrigemEnderecoId",
                table: "Viagens",
                column: "EnderecoOrigemEnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_VeiculoId",
                table: "Viagens",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Enderecos_EnderecoDestinoEnderecoId",
                table: "Viagens",
                column: "EnderecoDestinoEnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Enderecos_EnderecoOrigemEnderecoId",
                table: "Viagens",
                column: "EnderecoOrigemEnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Animais_AnimalId",
                table: "Viagens",
                column: "AnimalId",
                principalTable: "Animais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Veiculos_VeiculoId",
                table: "Viagens",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animais_Pessoas_ClientePessoaId",
                table: "Animais");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculos_Pessoas_MotoristaPessoaId",
                table: "Veiculos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Viagens_ViagemId",
                table: "Enderecos");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Viagens");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
