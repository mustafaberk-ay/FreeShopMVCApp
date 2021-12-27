using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FreeShop.Business.Abstract;
using FreeShop.DataAccess.Abstract;
using FreeShop.Entities.Concrete;

namespace FreeShop.Business.Concrete
{
    public class ProductCommentService : IProductCommentService
    {
        //readonly guvenlik icin kullanilir. Sadece 1 kere instance yapilabilir.
        private readonly IGenericRepository<ProductComment> _productCommentRepo;

        public ProductCommentService(IGenericRepository<ProductComment> productCommentRepo)
        {
            _productCommentRepo = productCommentRepo;
        }
        public List<ProductComment> GetAll(Expression<Func<ProductComment, bool>> filter = null)
        {
            return _productCommentRepo.GetAll(filter);
        }

        public ProductComment GetById(int id)
        {
            return _productCommentRepo.GetById(id);
        }

        public ProductComment Get(Expression<Func<ProductComment, bool>> filter)
        {
            return _productCommentRepo.Get(filter);
        }

        public int Insert(ProductComment t)
        {
            return _productCommentRepo.Insert(t);
        }

        public int Update(ProductComment t)
        {
            return _productCommentRepo.Update(t);
        }

        public int Delete(ProductComment t)
        {
            return _productCommentRepo.Delete(t);
        }
    }
}
