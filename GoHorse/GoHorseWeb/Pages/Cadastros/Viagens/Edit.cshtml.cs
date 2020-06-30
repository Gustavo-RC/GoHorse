using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoHorseClassLibrary;
using GoHorseDAL;

namespace GoHorseWeb.Pages.Viagens
{
    public class EditModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public EditModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Viagem Viagem { get; set; }

        //***Itens necessários para gravação
        public SelectList Veiculos { get; set; }
        public SelectList Animais { get; set; }
        public SelectList EnderecosOrigem { get; set; }
        public SelectList EnderecosDestino { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //***Tras do contexto
            Veiculos = new SelectList(_context.Veiculos, "Id", "Marca");
            Animais = new SelectList(_context.Animais, "Id", "Nome");
            EnderecosOrigem = new SelectList(_context.Enderecos, "Id", "Tipo");
            EnderecosDestino = new SelectList(_context.Enderecos, "Id", "Tipo");
            //***Inclui para visualização
            Viagem = await _context.Viagens
                .Include(Viagem => Viagem.Animal)
                .Include(Viagem => Viagem.Veiculo)
                .Include(Viagem => Viagem.EnderecoOrigem)
                .Include(Viagem => Viagem.EnderecoDestino)
                .FirstOrDefaultAsync(m => m.Id == id);
            //***Relacionamento original
            VeiculoId = Viagem.Veiculo.Id;
            AnimalId = Viagem.Animal.Id;
            EnderecoOrigemId = Viagem.EnderecoOrigem.Id;
            EnderecoDestinoId = Viagem.EnderecoDestino.Id;

            if (Viagem == null)
            {
                return NotFound();
            }
            return Page();
        }

        //***Itens necessários para gravação
        [BindProperty]
        public int VeiculoId { get; set; }
        [BindProperty]
        public int AnimalId { get; set; }
        [BindProperty]
        public int EnderecoOrigemId { get; set; }
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

            _context.Attach(Viagem).State = EntityState.Modified;

            try
            {
                //***Busca no contexto
                Veiculo veiculo = _context.Veiculos.Find(VeiculoId);
                Viagem.Veiculo = veiculo;
                Animal animal = _context.Animais.Find(AnimalId);
                Viagem.Animal = animal;
                Endereco enderecoOrigem = _context.Enderecos.Find(EnderecoOrigemId);
                Viagem.EnderecoOrigem = enderecoOrigem;
                Endereco enderecoDestino = _context.Enderecos.Find(EnderecoDestinoId);
                Viagem.EnderecoDestino = enderecoDestino;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViagemExists(Viagem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ViagemExists(int id)
        {
            return _context.Viagens.Any(e => e.Id == id);
        }
    }
}
