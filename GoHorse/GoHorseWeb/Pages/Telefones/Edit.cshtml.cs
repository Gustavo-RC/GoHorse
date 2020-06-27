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

namespace GoHorseWeb.Pages.Telefones
{
    public class EditModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public EditModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Telefone Telefone { get; set; }

        //***Cria a lista
        public SelectList Pessoas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //***Busca no contexto
            Pessoas = new SelectList(_context.Pessoas, "Id", "Nome");
            Telefone = await _context.Telefones
                .Include(Telefone => Telefone.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            //***Relacionamento original
            PessoaId = Telefone.Pessoa.Id;

            if (Telefone == null)
            {
                return NotFound();
            }
            return Page();
        }

        //***Itens necessários para gravação
        [BindProperty]
        public int PessoaId { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Telefone).State = EntityState.Modified;

            try
            {
                //***Busca no contexto
                Pessoa pessoa = _context.Pessoas.Find(PessoaId);
                Telefone.Pessoa = pessoa;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefoneExists(Telefone.Id))
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

        private bool TelefoneExists(int id)
        {
            return _context.Telefones.Any(e => e.Id == id);
        }
    }
}
