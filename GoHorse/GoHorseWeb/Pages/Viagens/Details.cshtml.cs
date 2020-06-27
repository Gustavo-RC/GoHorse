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
    public class DetailsModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public DetailsModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        public Viagem Viagem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //***Inclui para visualização
            Viagem = await _context.Viagens
                .Include(Viagem => Viagem.Animal)
                .Include(Viagem => Viagem.Veiculo)
                .Include(Viagem => Viagem.EnderecoOrigem)
                .Include(Viagem => Viagem.EnderecoOrigem)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Viagem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
