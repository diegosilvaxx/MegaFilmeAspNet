using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaFilme.Data;
using MegaFilme.Models;

namespace MegaFilme.Pages.Filmes
{
    public class DetailsModel : PageModel
    {
        private readonly MegaFilme.Data.ApplicationDbContext _context;

        public DetailsModel(MegaFilme.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public CadastroFilmes CadastroFilmes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CadastroFilmes = await _context.CadastroFilme.SingleOrDefaultAsync(m => m.Id == id);

            if (CadastroFilmes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
