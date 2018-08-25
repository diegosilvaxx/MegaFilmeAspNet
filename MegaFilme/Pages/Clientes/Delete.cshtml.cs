using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaFilme.Data;
using MegaFilme.Models;

namespace MegaFilme.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly MegaFilme.Data.ApplicationDbContext _context;

        public DeleteModel(MegaFilme.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CadastroCliente = await _context.CadastroClientes.FindAsync(id);

            if (CadastroCliente != null)
            {
                _context.CadastroClientes.Remove(CadastroCliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
