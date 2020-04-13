using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Business.Models
{
    public  class Endereco
    {
        public Guid? EnderecoId { get; set; }
        public string Nome { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
