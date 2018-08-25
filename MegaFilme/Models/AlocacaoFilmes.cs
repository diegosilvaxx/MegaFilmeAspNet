using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaFilme.Models
{
    public class AlocacaoFilmes
    {
        public AlocacaoFilmes()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string NomeFilme { get; set; }
        public string DataEntrega { get; set; }
        public string DataRetirada { get; set; }
    }
}
