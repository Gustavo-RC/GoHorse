using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GoHorseClassLibrary;
using GoHorseDAL;
using Microsoft.AspNetCore.Authorization;

namespace GoHorseWeb.Pages.Viagens
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public CreateModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //***Tras do contexto
            Veiculos = new SelectList(_context.Veiculos, "Id", "Marca");
            Animais = new SelectList(_context.Animais, "Id", "Nome");
            EnderecosOrigem = new SelectList(_context.Enderecos, "Id", "Tipo");
            EnderecosDestino = new SelectList(_context.Enderecos, "Id", "Tipo");

            return Page();
        }

        [BindProperty]
        public Viagem Viagem { get; set; }

        //***Itens necessários para gravação
        public SelectList Veiculos { get; set; }
        [BindProperty]
        public int VeiculoId { get; set; }
        public SelectList Animais { get; set; }
        [BindProperty]
        public int AnimalId { get; set; }
        public SelectList EnderecosOrigem { get; set; }
        [BindProperty]
        public int EnderecoOrigemId { get; set; }
        public SelectList EnderecosDestino { get; set; }
        [BindProperty]
        public int EnderecoDestinoId { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //***Busca no contexto
            Veiculo veiculo = _context.Veiculos.Find(VeiculoId);
            Viagem.Veiculo = veiculo;
            Animal animal = _context.Animais.Find(AnimalId);
            Viagem.Animal = animal;
            Endereco enderecoOrigem = _context.Enderecos.Find(EnderecoOrigemId);
            Viagem.EnderecoOrigem = enderecoOrigem;
            Endereco enderecoDestino = _context.Enderecos.Find(EnderecoDestinoId);
            Viagem.EnderecoDestino = enderecoDestino;

            _context.Viagens.Add(Viagem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}