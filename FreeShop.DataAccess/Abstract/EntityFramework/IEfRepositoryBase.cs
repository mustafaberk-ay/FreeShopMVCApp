using System;
using System.Collections.Generic;
using System.Text;
using FreeShop.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FreeShop.DataAccess.Abstract.EntityFramework
{
    public interface IEfRepositoryBase<T> : IGenericRepository<T> where T:IEntity, new()
    {

    }
}
