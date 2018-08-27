using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }
        public string NomeFilme { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataRetirada { get; set; }
        public float ValorDiaria { get; set; }
        public float ValorTotal { get; set; }

         
    }
}
