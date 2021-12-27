using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FreeShop.Business.Abstract;
using FreeShop.DataAccess.Abstract;
using FreeShop.Entities.Concrete;

namespace FreeShop.Business.Concrete
{
    public class ProductService : IProductService
    {
        //readonly guvenlik icin kullanilir. Sadece 1 kere instance yapilabilir.
        private readonly IGenericRepository<Product> _productRepo;

        public ProductService(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _productRepo.GetAll(filter);
        }

        public Product GetById(int id)
        {
            return _productRepo.GetById(id);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _productRepo.Get(filter);
        }

        public int Insert(Product t)
        {
            return _productRepo.Insert(t);
        }

        public int Update(Product t)
        {
            return _productRepo.Update(t);
        }

        public int Delete(Product t)
        {
            return _productRepo.Delete(t);
        }
    }
}
