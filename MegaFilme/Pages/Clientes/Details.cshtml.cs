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
    public class DetailsModel : PageModel
    {
        private readonly MegaFilme.Data.ApplicationDbContext _context;

        public DetailsModel(MegaFilme.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
