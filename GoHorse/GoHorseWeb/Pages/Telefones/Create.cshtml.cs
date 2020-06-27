using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GoHorseClassLibrary;
using GoHorseDAL;

namespace GoHorseWeb.Pages.Telefones
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
            Pessoas = new SelectList(_context.Pessoas, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public Telefone Telefone { get; set; }

        //***Itens necessários para gravação
        public SelectList Pessoas { get; set; }
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

            //***Busca no contexto
            Pessoa pessoa = _context.Pessoas.Find(PessoaId);
            Telefone.Pessoa = pessoa;

            _context.Telefones.Add(Telefone);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
