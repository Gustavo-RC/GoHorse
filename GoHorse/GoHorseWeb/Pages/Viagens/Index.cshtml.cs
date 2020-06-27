using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoHorseClassLibrary;
using GoHorseDAL;

namespace GoHorseWeb.Pages.Viagens
{
    public class IndexModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public IndexModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        public IList<Viagem> Viagem { get;set; }

        public async Task OnGetAsync()
        {
            //***Inclui no contexto
            Viagem = await _context.Viagens
                .Include(Viagem => Viagem.Veiculo)
                .Include(Viagem => Viagem.Animal)
                .Include(Viagem => Viagem.EnderecoOrigem)
                .Include(Viagem => Viagem.EnderecoDestino)
                .ToListAsync();
        }
    }
}
