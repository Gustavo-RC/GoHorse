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

namespace GoHorseWeb.Pages.Cartoes
{
    public class EditModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public EditModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cartao Cartao { get; set; }

        //***Cria a lista de clientes
        public SelectList Clientes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //***Busca o cliente no contexto
            Clientes = new SelectList(_context.Clientes, "Id", "Nome");
            Cartao = await _context.Cartoes
                .Include(Cartao => Cartao.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            //***Relacionamento original
            ClienteId = Cartao.Cliente.Id;

            if (Cartao == null)
            {
                return NotFound();
            }
            return Page();
        }

        //***Itens necessários para gravação
        [BindProperty]
        public int ClienteId { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cartao).State = EntityState.Modified;

            try
            {
                //***Itens necessarios para gravação
                Cliente cliente = _context.Clientes.Find(ClienteId);
                Cartao.Cliente = cliente;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoExists(Cartao.Id))
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

        private bool CartaoExists(int id)
        {
            return _context.Cartoes.Any(e => e.Id == id);
        }
    }
}
