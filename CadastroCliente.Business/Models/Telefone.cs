using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Business.Models
{
    public class Telefone
    {   
        public Guid? TelefoneId { get; set; }
        public string Tipo { get; set; }
        public int Numero { get; set; }
    }
}
