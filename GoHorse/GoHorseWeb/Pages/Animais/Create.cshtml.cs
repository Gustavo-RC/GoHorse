using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GoHorseClassLibrary;
using GoHorseDAL;

namespace GoHorseWeb.Pages.Animais
{
    public class CreateModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public CreateModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //***Tras o cliente do contexto
            Clientes = new SelectList(_context.Clientes, "Id", "Nome");

            return Page();
        }

        [BindProperty]
        public Animal Animal { get; set; }

        //***Itens necessários para gravação
        public SelectList Clientes { get; set; }
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

            //***Busca o cliente no contexto
            Cliente cliente = _context.Clientes.Find(ClienteId);
            Animal.Cliente = cliente;

            _context.Animais.Add(Animal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
