using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TesteSovos.Domain.Base;

namespace TesteSovos.Domain.Interface.Infrastructure
{
    public interface IRepositorioBase<T> where T : ModelBase
    {
        Task<List<T>> Listar();
        T RetornaObjeto(T entity);
        Task<T> BuscaQualquerParametro(Expression<Func<T, bool>> predicate);
        Task<List<T>> BuscaTodosQualquerParametro(Expression<Func<T, bool>> predicate);
        Task<T> Inserir(T entity);
        void InserirVarios(List<T> entities);
        void Atualizar(T entity);
        void AtualizarVarios(List<T> entities);
        void Excluir(T entity);
        void ExcluirVarios(List<T> entities);
        IQueryable<T> ConsultaJoin(T entity);
    }
}
