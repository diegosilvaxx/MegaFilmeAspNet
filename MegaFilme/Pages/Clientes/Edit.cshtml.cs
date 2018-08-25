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

namespace MegaFilme.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly MegaFilme.Data.ApplicationDbContext _context;

        public EditModel(MegaFilme.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CadastroCliente CadastroCliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CadastroCliente = await _context.CadastroClientes.SingleOrDefaultAsync(m => m.Id == id);

            if (CadastroCliente == null)
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

            _context.Attach(CadastroCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroClienteExists(CadastroCliente.Id))
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

        private bool CadastroClienteExists(int id)
        {
            return _context.CadastroClientes.Any(e => e.Id == id);
        }
    }
}
