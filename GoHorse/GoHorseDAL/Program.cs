using GoHorseClassLibrary;
using System;
using System.Linq;

namespace GoHorseDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 1. Criar Objetos a serem gravados no banco

            //Cliente cliente = new Cliente();
            //cliente.Nome = "João";

            //Cartao cartao = new Cartao();
            //cartao.NCartao = "1234";

            //Animal animal = new Animal();
            //animal.Nome = "Lulu";

            //Conta conta = new Conta();
            //conta.Banco = "LeftBank";

            //Endereco endereco1 = new Endereco();
            //endereco1.Cidade = "Paranaguá";

            //Endereco endereco2 = new Endereco();
            //endereco2.Cidade = "Cerro Azul";

            //Endereco endereco3 = new Endereco();
            //endereco3.Cidade = "Sertãozinho";

            //Endereco endereco4 = new Endereco();
            //endereco4.Cidade = "Lapa";

            //Motorista motorista = new Motorista();
            //motorista.NRegistroCnh = "15489625";

            //Pagamento pagamento = new Pagamento();

            //Telefone telefone1 = new Telefone();
            //telefone1.Numero = "9090";

            //Telefone telefone2 = new Telefone();
            //telefone2.Numero = "90";

            //Veiculo veiculo = new Veiculo();
            //veiculo.Modelo = "Pandero RS";

            //Viagem viagem = new Viagem();
            //viagem.ValorViagem = 300.0;

            //// 2. Estabelecer os relacionamentos
            //cliente.Animais.Add(animal);
            //cliente.Cartoes.Add(cartao);
            //cliente.Telefones.Add(telefone1);
            //cliente.Endereco = endereco1;

            //motorista.Contas.Add(conta);
            //motorista.Veiculos.Add(veiculo);
            //motorista.Telefones.Add(telefone2);
            //motorista.Endereco = endereco2;

            //conta.Motorista = motorista;

            //cartao.Cliente = cliente;

            //veiculo.Motorista = motorista;

            //animal.Cliente = cliente;

            //viagem.Veiculo = veiculo;
            //viagem.Animal = animal;
            //viagem.Enderecos.Add(endereco3);
            //viagem.Enderecos.Add(endereco4);

            //pagamento.Viagem = viagem;
            //pagamento.Cartao = cartao;
            //pagamento.Conta = conta;


            //// 3. Criar o contexto para gravar na base de dados

            //GoHorseContext ctx = new GoHorseContext();
            //ctx.Clientes.Add(cliente);
            //ctx.Cartoes.Add(cartao);
            //ctx.Animais.Add(animal);
            //ctx.Contas.Add(conta);
            //ctx.Enderecos.Add(endereco1);
            //ctx.Enderecos.Add(endereco2);
            //ctx.Enderecos.Add(endereco3);
            //ctx.Enderecos.Add(endereco4);
            //ctx.Motoristas.Add(motorista);
            //ctx.Pagamentos.Add(pagamento);
            //ctx.Telefones.Add(telefone1);
            //ctx.Telefones.Add(telefone2);
            //ctx.Veiculos.Add(veiculo);
            //ctx.Viagens.Add(viagem);

            //ctx.SaveChanges();

            //Console.WriteLine("Dados gravados com sucesso!");

            GoHorseContext ctx = new GoHorseContext();
            var clientes = ctx.Clientes.ToList();
            foreach (var cliente in clientes)
            {
                Console.WriteLine("Nome: " + cliente.Nome);

                var animais = from a in ctx.Animais
                              where a.Cliente.Cpf == cliente.Cpf
                              select a;

                var cartoes = from b in ctx.Cartoes
                              where b.Cliente.Cpf == cliente.Cpf
                              select b;

                var telefones = from c in ctx.Telefones
                                where c.Pessoa.PessoaId == cliente.PessoaId
                                select c;

                foreach (var animal in animais)
                {
                    Console.WriteLine("Animal: " + animal.Nome);
                }

                foreach (var cartao in cartoes)
                {
                    Console.WriteLine("Numero: " + cartao.NCartao);
                }

                foreach (var telefone in telefones)
                {
                    Console.WriteLine("Telefone: " + telefone.Numero);
                }
            }
        }
    }
}
