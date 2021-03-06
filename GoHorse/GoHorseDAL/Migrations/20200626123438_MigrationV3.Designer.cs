﻿// <auto-generated />
using System;
using GoHorseDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GoHorseDAL.Migrations
{
    [DbContext(typeof(GoHorseContext))]
    [Migration("20200626123438_MigrationV3")]
    partial class MigrationV3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GoHorseClassLibrary.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("DataNascimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NRegistro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Raca")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Cartao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Cv")
                        .HasColumnType("int");

                    b.Property<string>("NCartao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Validade")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cartoes");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Banco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MotoristaId")
                        .HasColumnType("int");

                    b.Property<string>("NConta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MotoristaId");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Endereco");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CartaoId")
                        .HasColumnType("int");

                    b.Property<int?>("ContaId")
                        .HasColumnType("int");

                    b.Property<int?>("ViagemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartaoId");

                    b.HasIndex("ContaId");

                    b.HasIndex("ViagemId");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataNascimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Pessoas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pessoa");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnoFabricacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MotoristaId")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MotoristaId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Viagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnimalId")
                        .HasColumnType("int");

                    b.Property<string>("DataDestino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataOrigem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnderecoDestinoId")
                        .HasColumnType("int");

                    b.Property<int?>("EnderecoOrigemId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("ValorViagem")
                        .HasColumnType("float");

                    b.Property<int?>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("EnderecoDestinoId");

                    b.HasIndex("EnderecoOrigemId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Viagens");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Parada", b =>
                {
                    b.HasBaseType("GoHorseClassLibrary.Endereco");

                    b.Property<int>("NumeroParada")
                        .HasColumnType("int");

                    b.Property<int?>("ViagemId")
                        .HasColumnType("int");

                    b.HasIndex("ViagemId");

                    b.HasDiscriminator().HasValue("Parada");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Cliente", b =>
                {
                    b.HasBaseType("GoHorseClassLibrary.Pessoa");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Motorista", b =>
                {
                    b.HasBaseType("GoHorseClassLibrary.Pessoa");

                    b.Property<string>("CategoriaCnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NRegistroCnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValidadeCnh")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Motorista");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Animal", b =>
                {
                    b.HasOne("GoHorseClassLibrary.Cliente", "Cliente")
                        .WithMany("Animais")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Cartao", b =>
                {
                    b.HasOne("GoHorseClassLibrary.Cliente", "Cliente")
                        .WithMany("Cartoes")
                        .HasForeignKey("ClienteId");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Conta", b =>
                {
                    b.HasOne("GoHorseClassLibrary.Motorista", "Motorista")
                        .WithMany("Contas")
                        .HasForeignKey("MotoristaId");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Pagamento", b =>
                {
                    b.HasOne("GoHorseClassLibrary.Cartao", "Cartao")
                        .WithMany()
                        .HasForeignKey("CartaoId");

                    b.HasOne("GoHorseClassLibrary.Conta", "Conta")
                        .WithMany()
                        .HasForeignKey("ContaId");

                    b.HasOne("GoHorseClassLibrary.Viagem", "Viagem")
                        .WithMany()
                        .HasForeignKey("ViagemId");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Pessoa", b =>
                {
                    b.HasOne("GoHorseClassLibrary.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Telefone", b =>
                {
                    b.HasOne("GoHorseClassLibrary.Pessoa", "Pessoa")
                        .WithMany("Telefones")
                        .HasForeignKey("PessoaId");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Veiculo", b =>
                {
                    b.HasOne("GoHorseClassLibrary.Motorista", "Motorista")
                        .WithMany("Veiculos")
                        .HasForeignKey("MotoristaId");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Viagem", b =>
                {
                    b.HasOne("GoHorseClassLibrary.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId");

                    b.HasOne("GoHorseClassLibrary.Endereco", "EnderecoDestino")
                        .WithMany()
                        .HasForeignKey("EnderecoDestinoId");

                    b.HasOne("GoHorseClassLibrary.Endereco", "EnderecoOrigem")
                        .WithMany()
                        .HasForeignKey("EnderecoOrigemId");

                    b.HasOne("GoHorseClassLibrary.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId");
                });

            modelBuilder.Entity("GoHorseClassLibrary.Parada", b =>
                {
                    b.HasOne("GoHorseClassLibrary.Viagem", "Viagem")
                        .WithMany("Paradas")
                        .HasForeignKey("ViagemId");
                });
#pragma warning restore 612, 618
        }
    }
}
