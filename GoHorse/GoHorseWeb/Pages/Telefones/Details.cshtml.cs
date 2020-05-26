using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoHorseClassLibrary;
using GoHorseDAL;

namespace GoHorseWeb.Pages.Telefones
{
    public class DetailsModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public DetailsModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        public Telefone Telefone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Telefone = await _context.Telefones.FirstOrDefaultAsync(m => m.Id == id);

            if (Telefone == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
