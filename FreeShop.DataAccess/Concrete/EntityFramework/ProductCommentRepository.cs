using System;
using System.Collections.Generic;
using System.Text;
using FreeShop.DataAccess.Abstract.EntityFramework.Context;
using FreeShop.Entities.Concrete;

namespace FreeShop.DataAccess.Concrete.EntityFramework
{
    public class ProductCommentRepository : EfRepositoryBase<ProductComment, FreeShopDbContext>
    {
    }
}
