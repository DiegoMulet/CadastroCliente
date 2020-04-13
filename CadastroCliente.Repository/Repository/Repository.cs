using CadastroCliente.Business.Models;
using CadastroCliente.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static CadastroCliente.Business.Interfaces.IRepository;

namespace CadastroCliente.Repository.Repository
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : ModelBase, new()
    {
        protected readonly CadastroClienteContext Db;
        protected readonly DbSet<TModel> DbSet;

        protected Repository(CadastroClienteContext db)
        {
            Db = db;
            DbSet = db.Set<TModel>();
            //Db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<TModel>> Buscar(Expression<Func<TModel, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TModel> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TModel>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual void Adicionar(TModel entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Atualizar(TModel entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(new TModel { Id = id });
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
