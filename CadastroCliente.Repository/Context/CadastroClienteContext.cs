using CadastroCliente.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroCliente.Repository.Context
{
    public class CadastroClienteContext : DbContext
    {
        public CadastroClienteContext(DbContextOptions<CadastroClienteContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroClienteContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
