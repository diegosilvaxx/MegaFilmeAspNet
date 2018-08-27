﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaFilme.Models
{
    public class CadastroCliente
    {
        public CadastroCliente()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string NumCasa { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }


        public string Email { get; set; }
    }
}
