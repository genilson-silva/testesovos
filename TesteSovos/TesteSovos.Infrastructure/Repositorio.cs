using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TesteSovos.Domain.Base;
using TesteSovos.Domain.Interface.Infrastructure;
using TesteSovos.Infrastructure.Context;

namespace TesteSovos.Infrastructure
{
    public class Repositorio<T> : IRepositorioBase<T> where T : ModelBase
    {
        private IQueryable<T> Query { get; set; }
        protected ApplicationDbContext RepositoryContext = new ApplicationDbContext();


        public async Task<List<T>> Listar()
        {
            var all = RepositoryContext.Set<T>().ToList();
            return all;
        }

        public async Task<T> Inserir(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
            RepositoryContext.SaveChanges();
            return entity;
        }

        public void InserirVarios(List<T> entities)
        {
            RepositoryContext.Set<T>().AddRange(entities);
            RepositoryContext.SaveChanges();
        }

        public void Atualizar(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            RepositoryContext.SaveChanges();
        }

        public void AtualizarVarios(List<T> entities)
        {
            RepositoryContext.Set<T>().UpdateRange(entities);
            RepositoryContext.SaveChanges();
        }

        public void Excluir(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            RepositoryContext.SaveChanges();
        }

        public void ExcluirVarios(List<T> entities)
        {
            RepositoryContext.Set<T>().RemoveRange(entities);
            RepositoryContext.SaveChanges();
        }

        public async Task<T> BuscaQualquerParametro(Expression<Func<T, bool>> predicate)
        {
            var result = RepositoryContext.Set<T>().Where(predicate).FirstOrDefault();
            return result;
        }

        public async Task<List<T>> BuscaTodosQualquerParametro(Expression<Func<T, bool>> predicate)
        {
            var result = RepositoryContext.Set<T>().Where(predicate).ToList();
            return result;
        }

        public IQueryable<T> ConsultaJoin(T entity)
        {
            var RepositoryContext = new ApplicationDbContext();
            this.Query = RepositoryContext.Set<T>();
            return this.Query;
        }

        public T RetornaObjeto(T entity)
        {
            return entity;
        }
    }
}
