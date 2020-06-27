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

namespace GoHorseWeb.Pages.Motoristas
{
    public class EditModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public EditModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Motorista Motorista { get; set; }

        //***Cria a lista
        public SelectList Enderecos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //***Busca no contexto
            Enderecos = new SelectList(_context.Enderecos, "Id", "Tipo");
            Motorista = await _context.Motoristas
                .Include(Motorista => Motorista.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            //***Relacionamento original
            EnderecoId = Motorista.Endereco.Id;

            if (Motorista == null)
            {
                return NotFound();
            }
            return Page();
        }

        //***Itens necessários para gravação
        [BindProperty]
        public int EnderecoId { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Motorista).State = EntityState.Modified;

            try
            {
                //***Itens necessarios para gravação
                Endereco endereco = _context.Enderecos.Find(EnderecoId);
                Motorista.Endereco = endereco;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoristaExists(Motorista.Id))
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

        private bool MotoristaExists(int id)
        {
            return _context.Motoristas.Any(e => e.Id == id);
        }
    }
}
