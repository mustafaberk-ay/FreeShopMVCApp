using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FreeShop.Business.Abstract;
using FreeShop.DataAccess.Abstract;
using FreeShop.Entities.Concrete;

namespace FreeShop.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        //readonly guvenlik icin kullanilir. Sadece 1 kere instance yapilabilir.
        private readonly IGenericRepository<Category> _categoryRepo;

        public CategoryService(IGenericRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryRepo.GetAll(filter);
        }

        public Category GetById(int id)
        {
            return _categoryRepo.GetById(id);
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _categoryRepo.Get(filter);
        }

        public int Insert(Category t)
        {
            return _categoryRepo.Insert(t);
        }

        public int Update(Category t)
        {
            return _categoryRepo.Update(t);
        }

        public int Delete(Category t)
        {
            return _categoryRepo.Delete(t);
        }
    }
}
