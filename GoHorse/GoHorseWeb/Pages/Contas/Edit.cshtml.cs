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

namespace GoHorseWeb.Pages.Contas
{
    public class EditModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public EditModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Conta Conta { get; set; }

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
            Conta = await _context.Contas
                .Include(Conta => Conta.Motorista)
                .FirstOrDefaultAsync(m => m.Id == id);
            //***Relacionamento original
            MotoristaId = Conta.Motorista.Id;

            if (Conta == null)
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

            _context.Attach(Conta).State = EntityState.Modified;

            try
            {
                //***Itens necessarios para gravação
                Motorista motorista = _context.Motoristas.Find(MotoristaId);
                Conta.Motorista = motorista;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaExists(Conta.Id))
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

        private bool ContaExists(int id)
        {
            return _context.Contas.Any(e => e.Id == id);
        }
    }
}
