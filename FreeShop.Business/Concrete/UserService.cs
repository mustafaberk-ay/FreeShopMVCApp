using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FreeShop.Business.Abstract;
using FreeShop.DataAccess.Abstract;
using FreeShop.Entities.Concrete;

namespace FreeShop.Business.Concrete
{
    public class UserService : IUserService
    {
        //readonly guvenlik icin kullanilir. Sadece 1 kere instance yapilabilir.
        private readonly IGenericRepository<User> _userRepo;

        public UserService(IGenericRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _userRepo.GetAll(filter);
        }

        public User GetById(int id)
        {
            return _userRepo.GetById(id);
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            return _userRepo.Get(filter);
        }

        public int Insert(User t)
        {
            return _userRepo.Insert(t);
        }

        public int Update(User t)
        {
            return _userRepo.Update(t);
        }

        public int Delete(User t)
        {
            return _userRepo.Delete(t);
        }
    }
}
