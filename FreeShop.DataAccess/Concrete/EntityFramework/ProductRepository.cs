using System;
using System.Collections.Generic;
using System.Text;
using FreeShop.DataAccess.Abstract.EntityFramework.Context;
using FreeShop.Entities.Concrete;

namespace FreeShop.DataAccess.Concrete.EntityFramework
{
    public class ProductRepository : EfRepositoryBase<Product, FreeShopDbContext>
    {
    }
}
