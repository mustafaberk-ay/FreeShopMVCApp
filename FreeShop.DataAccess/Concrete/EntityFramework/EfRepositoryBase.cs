using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FreeShop.DataAccess.Abstract.EntityFramework;
using FreeShop.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FreeShop.DataAccess.Concrete.EntityFramework
{
    public class EfRepositoryBase<T, TContext> : IEfRepositoryBase<T> where T:IEntity,new() where TContext:DbContext, new()
    {
        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
            }
        }

        public T GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().SingleOrDefault(x => x.Id == id);
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Where(filter).FirstOrDefault();
            }
        }

        public int Insert(T t)
        {
            using (var context = new TContext())
            {
                var entry = context.Entry(t);
                entry.State = EntityState.Added;
                return context.SaveChanges();
            }
        }

        public int Update(T t)
        {
            using (var context = new TContext())
            {
                var entry = context.Entry(t);
                entry.State = EntityState.Modified;
                return context.SaveChanges();
            }
        }

        public int Delete(T t)
        {
            using (var context = new TContext())
            {
                var entry = context.Entry(t);
                entry.State = EntityState.Deleted
                    ;
                return context.SaveChanges();
            }
        }
    }
}
