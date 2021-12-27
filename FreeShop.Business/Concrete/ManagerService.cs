using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FreeShop.Business.Abstract;
using FreeShop.DataAccess.Abstract;
using FreeShop.Entities.Concrete;

namespace FreeShop.Business.Concrete
{
    public class ManagerService : IManagerService
    {
        //readonly guvenlik icin kullanilir. Sadece 1 kere instance yapilabilir.
        private readonly IManagerRepository _managerRepo;

        public ManagerService(IManagerRepository managerRepo)
        {
            _managerRepo = managerRepo;
        }
        public List<Manager> GetAll(Expression<Func<Manager, bool>> filter = null)
        {
            return _managerRepo.GetAll(filter);
        }

        public Manager GetById(int id)
        {
            return _managerRepo.GetById(id);
        }

        public Manager Get(Expression<Func<Manager, bool>> filter)
        {
            return _managerRepo.Get(filter);
        }

        public int Insert(Manager t)
        {
            return _managerRepo.Insert(t);
        }

        public int Update(Manager t)
        {
            return _managerRepo.Update(t);
        }

        public int Delete(Manager t)
        {
            return _managerRepo.Delete(t);
        }

        public Manager Login(string username, string password)
        {
            return _managerRepo.Login(username, password);
        }

        public Manager GetByEmail(string email)
        {
            return _managerRepo.GetByEmail(email);
        }
    }
}
