using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaFilme.Data;
using MegaFilme.Models;

namespace MegaFilme.Pages.Filmes
{
    public class CreateModel : PageModel
    {
        private readonly MegaFilme.Data.ApplicationDbContext _context;

        public CreateModel(MegaFilme.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CadastroFilmes CadastroFilmes { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CadastroFilme.Add(CadastroFilmes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}