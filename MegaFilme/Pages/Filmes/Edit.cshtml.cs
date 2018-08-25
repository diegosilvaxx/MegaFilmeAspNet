using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaFilme.Data;
using MegaFilme.Models;

namespace MegaFilme.Pages.Filmes
{
    public class EditModel : PageModel
    {
        private readonly MegaFilme.Data.ApplicationDbContext _context;

        public EditModel(MegaFilme.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CadastroFilmes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroFilmesExists(CadastroFilmes.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CadastroFilmesExists(int id)
        {
            return _context.CadastroFilme.Any(e => e.Id == id);
        }
    }
}
