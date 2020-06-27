using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GoHorseClassLibrary;
using GoHorseDAL;

namespace GoHorseWeb.Pages.Pagamentos
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
            Viagens = new SelectList(_context.Viagens, "Id", "Status");
            Cartoes = new SelectList(_context.Cartoes, "Id", "Nome");
            Contas = new SelectList(_context.Contas, "Id", "Agencia");

            return Page();
        }

        [BindProperty]
        public Pagamento Pagamento { get; set; }

        //***Itens necessários para gravação
        public SelectList Viagens { get; set; }
        [BindProperty]
        public int ViagemId { get; set; }
        public SelectList Cartoes { get; set; }
        [BindProperty]
        public int CartaoId { get; set; }
        public SelectList Contas { get; set; }
        [BindProperty]
        public int ContaId { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //***Busca no contexto
            Viagem viagem = _context.Viagens.Find(ViagemId);
            Pagamento.Viagem = viagem;
            Cartao cartao = _context.Cartoes.Find(CartaoId);
            Pagamento.Cartao = cartao;
            Conta conta = _context.Contas.Find(ContaId);
            Pagamento.Conta = conta;

            _context.Pagamentos.Add(Pagamento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
