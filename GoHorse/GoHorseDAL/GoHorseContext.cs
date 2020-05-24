using GoHorseClassLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoHorseDAL
{
    public class GoHorseContext : DbContext
    {
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Parada> Paradas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Integrated Security=True;Database=GoHorseDB;MultipleActiveResultSets=True;"
                );
        }
    }
}
