using DemoClassLibrary.Interface;
using DemoClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoClassLibrary.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        void IRepository<TEntity>.Add(TEntity instance)
        {
            try
            {
                var db = new testEntities();
                db.Set<TEntity>().Add(instance);
                db.SaveChanges();

            }
            catch (Exception)
            {

            }
        }

        void IRepository<TEntity>.Delete(TEntity instance)
        {
            try
            {
                var db = new testEntities();
                db.Entry(instance).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            var db = new testEntities();
            return db.Set<TEntity>().FirstOrDefault(predicate);
        }

        public double GetMax(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, double>> predicate2)
        {
            var db = new testEntities();
            var temp = db.Set<TEntity>().Where(predicate);
            double Max_num = 0;
            if (temp != null)
            {
                if (temp.Count() > 0)
                {
                    Max_num = temp.Max(predicate2);
                }

            }

            Max_num = Max_num + 1;

            return Max_num;
        }

        IQueryable<TEntity> IRepository<TEntity>.GetAll()
        {
            var db = new testEntities();
            return db.Set<TEntity>().AsQueryable();
        }

        TEntity IRepository<TEntity>.GetFist()
        {
            var db = new testEntities();
            return db.Set<TEntity>().FirstOrDefault();
        }

        void IRepository<TEntity>.Update(TEntity instance)
        {
            try
            {
                var db = new testEntities();
                db.Entry(instance).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }
}
