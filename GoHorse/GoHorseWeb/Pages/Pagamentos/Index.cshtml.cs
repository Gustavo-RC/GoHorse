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
    public class IndexModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public IndexModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        public IList<Pagamento> Pagamento { get;set; }

        public async Task OnGetAsync()
        {
            //***Inclui no contexto
            Pagamento = await _context.Pagamentos
                .Include(Pagamento => Pagamento.Viagem)
                .Include(Pagamento => Pagamento.Cartao)
                .Include(Pagamento => Pagamento.Conta)
                .ToListAsync();
        }
    }
}
