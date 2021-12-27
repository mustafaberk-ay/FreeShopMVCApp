using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FreeShop.Business.Abstract;
using FreeShop.DataAccess.Abstract;
using FreeShop.Entities.Concrete;

namespace FreeShop.Business.Concrete
{
    public class ProductPhotoService : IProductPhotoService
    {
        //readonly guvenlik icin kullanilir. Sadece 1 kere instance yapilabilir.
        private readonly IGenericRepository<ProductPhoto> _productPhotoRepo;

        public ProductPhotoService(IGenericRepository<ProductPhoto> productPhotoRepo)
        {
            _productPhotoRepo = productPhotoRepo;
        }
        public List<ProductPhoto> GetAll(Expression<Func<ProductPhoto, bool>> filter = null)
        {
            return _productPhotoRepo.GetAll(filter);
        }

        public ProductPhoto GetById(int id)
        {
            return _productPhotoRepo.GetById(id);
        }

        public ProductPhoto Get(Expression<Func<ProductPhoto, bool>> filter)
        {
            return _productPhotoRepo.Get(filter);
        }

        public int Insert(ProductPhoto t)
        {
            return _productPhotoRepo.Insert(t);
        }

        public int Update(ProductPhoto t)
        {
            return _productPhotoRepo.Update(t);
        }

        public int Delete(ProductPhoto t)
        {
            return _productPhotoRepo.Delete(t);
        }
    }
}
