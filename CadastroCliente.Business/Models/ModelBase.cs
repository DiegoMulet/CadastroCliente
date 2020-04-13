using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Business.Models
{
    public class ModelBase
    {
        protected ModelBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
