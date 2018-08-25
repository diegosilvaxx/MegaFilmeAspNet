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
    public class IndexModel : PageModel
    {
        private readonly MegaFilme.Data.ApplicationDbContext _context;

        public IndexModel(MegaFilme.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CadastroCliente> CadastroCliente { get;set; }

        public async Task OnGetAsync()
        {
            CadastroCliente = await _context.CadastroClientes.ToListAsync();
        }
    }
}
