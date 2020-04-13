using CadastroCliente.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Business.Interfaces
{
    public interface IRepository
    {
        public interface IRepository<TModel> : IDisposable where TModel : ModelBase
        {
            void Adicionar(TModel entity);
            Task<TModel> ObterPorId(Guid id);
            Task<List<TModel>> ObterTodos();
            void Atualizar(TModel entity);
            void Remover(Guid id);
            Task<IEnumerable<TModel>> Buscar(Expression<Func<TModel, bool>> predicate);
            Task<int> SaveChanges();
        }
    }
}
