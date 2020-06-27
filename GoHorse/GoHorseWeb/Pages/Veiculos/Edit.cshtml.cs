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

namespace GoHorseWeb.Pages.Veiculos
{
    public class EditModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public EditModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Veiculo Veiculo { get; set; }

        //***Cria a lista
        public SelectList Motoristas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //***Busca no contexto
            Motoristas = new SelectList(_context.Motoristas, "Id", "Nome");
            Veiculo = await _context.Veiculos
                .Include(Conta => Conta.Motorista)
                .FirstOrDefaultAsync(m => m.Id == id);
            //***Relacionamento original
            MotoristaId = Veiculo.Motorista.Id;

            if (Veiculo == null)
            {
                return NotFound();
            }
            return Page();
        }

        //***Itens necessários para gravação
        [BindProperty]
        public int MotoristaId { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Veiculo).State = EntityState.Modified;

            try
            {
                //***Itens necessarios para gravação
                Motorista motorista = _context.Motoristas.Find(MotoristaId);
                Veiculo.Motorista = motorista;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(Veiculo.Id))
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

        private bool VeiculoExists(int id)
        {
            return _context.Veiculos.Any(e => e.Id == id);
        }
    }
}
