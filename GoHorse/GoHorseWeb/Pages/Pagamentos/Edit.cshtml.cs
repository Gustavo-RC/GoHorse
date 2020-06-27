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

namespace GoHorseWeb.Pages.Pagamentos
{
    public class EditModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public EditModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pagamento Pagamento { get; set; }

        //***Cria a lista
        public SelectList Viagens { get; set; }
        public SelectList Cartoes { get; set; }
        public SelectList Contas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //***Busca no contexto
            Viagens = new SelectList(_context.Viagens, "Id", "Status");
            Cartoes = new SelectList(_context.Cartoes, "Id", "Nome");
            Contas = new SelectList(_context.Contas, "Id", "Agencia");
            Pagamento = await _context.Pagamentos
                .Include(Pagamento => Pagamento.Viagem)
                .Include(Pagamento => Pagamento.Cartao)
                .Include(Pagamento => Pagamento.Conta)
                .FirstOrDefaultAsync(m => m.Id == id);
            //***Relacionamento original
            ViagemId = Pagamento.Viagem.Id;
            CartaoId = Pagamento.Cartao.Id;
            ContaId = Pagamento.Conta.Id;

            if (Pagamento == null)
            {
                return NotFound();
            }
            return Page();
        }

        //***Itens necessários para gravação
        [BindProperty]
        public int ViagemId { get; set; }
        [BindProperty]
        public int CartaoId { get; set; }
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

            _context.Attach(Pagamento).State = EntityState.Modified;

            try
            {
                //***Busca no contexto
                Viagem viagem = _context.Viagens.Find(ViagemId);
                Pagamento.Viagem = viagem;
                Cartao cartao = _context.Cartoes.Find(CartaoId);
                Pagamento.Cartao = cartao;
                Conta conta = _context.Contas.Find(ContaId);
                Pagamento.Conta = conta;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentoExists(Pagamento.Id))
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

        private bool PagamentoExists(int id)
        {
            return _context.Pagamentos.Any(e => e.Id == id);
        }
    }
}
