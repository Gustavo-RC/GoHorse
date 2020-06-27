using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoHorseClassLibrary;
using GoHorseDAL;

namespace GoHorseWeb.Pages.Pagamentos
{
    public class DetailsModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public DetailsModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        public Pagamento Pagamento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //***Inclui para visualização
            Pagamento = await _context.Pagamentos
                .Include(Pagamento => Pagamento.Viagem)
                .Include(Pagamento => Pagamento.Cartao)
                .Include(Pagamento => Pagamento.Conta)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Pagamento == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
