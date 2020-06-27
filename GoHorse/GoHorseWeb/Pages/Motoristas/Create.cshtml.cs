﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GoHorseClassLibrary;
using GoHorseDAL;

namespace GoHorseWeb.Pages.Motoristas
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
            Enderecos = new SelectList(_context.Enderecos, "Id", "Tipo");
            return Page();
        }

        [BindProperty]
        public Motorista Motorista { get; set; }

        //***Itens necessários para gravação
        public SelectList Enderecos { get; set; }
        [BindProperty]
        public int EnderecoId { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //***Busca no contexto
            Endereco endereco = _context.Enderecos.Find(EnderecoId);
            Motorista.Endereco = endereco;

            _context.Motoristas.Add(Motorista);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
