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

namespace GoHorseWeb.Pages.Paradas
{
    public class EditModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public EditModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Parada Parada { get; set; }

        //***Cria a lista
        public SelectList Viagens { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //***Busca no contexto
            Viagens = new SelectList(_context.Viagens, "Id", "Status");
            Parada = await _context.Paradas
                .Include(Parada => Parada.Viagem)
                .FirstOrDefaultAsync(m => m.Id == id);
            //***Relacionamento original
            ViagemId = Parada.Viagem.Id;

            if (Parada == null)
            {
                return NotFound();
            }
            return Page();
        }

        //***Itens necessários para gravação
        [BindProperty]
        public int ViagemId { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Parada).State = EntityState.Modified;

            try
            {
                //***Busca no contexto
                Viagem viagem = _context.Viagens.Find(ViagemId);
                Parada.Viagem = viagem;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParadaExists(Parada.Id))
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

        private bool ParadaExists(int id)
        {
            return _context.Paradas.Any(e => e.Id == id);
        }
    }
}
