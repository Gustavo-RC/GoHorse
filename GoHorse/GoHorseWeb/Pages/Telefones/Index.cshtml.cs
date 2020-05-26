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
    public class IndexModel : PageModel
    {
        private readonly GoHorseDAL.GoHorseContext _context;

        public IndexModel(GoHorseDAL.GoHorseContext context)
        {
            _context = context;
        }

        public IList<Telefone> Telefone { get;set; }

        public async Task OnGetAsync()
        {
            Telefone = await _context.Telefones.ToListAsync();
        }
    }
}
