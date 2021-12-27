using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FreeShop.Entities.Abstract;

namespace FreeShop.Business.Abstract
{
    public interface IGenericService<T> where T:IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> filter);
        int Insert(T t);
        int Update(T t);
        int Delete(T t);
    }
}
