using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaFilme.Models
{
    public class CadastroFilmes
    {
        public CadastroFilmes()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public string Descricao { get; set; }
    }
}
