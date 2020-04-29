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

            //Animal animal = new Animal();
            //animal.Nome = "Lulu";

            //// 2. Estabelecer os relacionamentos
            //cliente.Animais.Add(animal);
            //animal.Dono = cliente;

            //// 3. Criar o contexto para gravar na base de dados

            //GoHorseContext ctx = new GoHorseContext();
            //ctx.Clientes.Add(cliente);
            //ctx.Animais.Add(animal);
            //ctx.SaveChanges();

            //Console.WriteLine("Dados gravados com sucesso!");

            GoHorseContext ctx = new GoHorseContext();
            var clientes = ctx.Clientes.ToList();
            foreach (var cliente in clientes)
            {
                Console.WriteLine("Nome: " + cliente.Nome);

                var animais = from a in ctx.Animais 
                              where a.Dono.ClienteId == cliente.ClienteId 
                              select a;

                foreach (var animal in animais)
                {
                    Console.WriteLine("Animal: " + animal.Nome);
                }
            }
        }
    }
}
