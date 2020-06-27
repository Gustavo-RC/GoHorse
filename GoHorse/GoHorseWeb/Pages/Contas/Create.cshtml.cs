using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GoHorseClassLibrary;
using GoHorseDAL;

namespace GoHorseWeb.Pages.Contas
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
            //***Tras do contexto
            Motoristas = new SelectList(_context.Motoristas, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public Conta Conta { get; set; }

        //***Itens necessários para gravação
        public SelectList Motoristas { get; set; }
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

            //***Busca no contexto
            Motorista motorista = _context.Motoristas.Find(MotoristaId);
            Conta.Motorista = motorista;

            _context.Contas.Add(Conta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
