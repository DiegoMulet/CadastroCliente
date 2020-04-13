using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Business.Models
{
   public class Cliente
    {
        public Guid? ClienteId { get; set; }
        public string Nome { get; set; }
        public int Documento { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public Endereco Endereco { get; set; }
        public Telefone Telefone { get; set; }
    }
}
