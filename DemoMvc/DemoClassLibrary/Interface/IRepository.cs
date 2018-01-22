using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoClassLibrary.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity instance);
        void Update(TEntity instance);
        void Delete(TEntity instance);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        double GetMax(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, double>> predicate2);
        TEntity GetFist(string conntr);
        IQueryable<TEntity> GetAll(string conntr);
    }
}
