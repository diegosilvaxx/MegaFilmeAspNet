using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaFilme.Data;
using MegaFilme.Models;

namespace MegaFilme.Pages.Account.Alocacao
{
    public class DeleteModel : PageModel
    {
        private readonly MegaFilme.Data.ApplicationDbContext _context;

        public DeleteModel(MegaFilme.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AlocacaoFilmes AlocacaoFilmes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AlocacaoFilmes = await _context.AlocacaoFilme.SingleOrDefaultAsync(m => m.Id == id);

            if (AlocacaoFilmes == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AlocacaoFilmes = await _context.AlocacaoFilme.FindAsync(id);

            if (AlocacaoFilmes != null)
            {
                _context.AlocacaoFilme.Remove(AlocacaoFilmes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
