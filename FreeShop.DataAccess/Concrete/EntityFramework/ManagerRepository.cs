using System;
using System.Collections.Generic;
using System.Text;
using FreeShop.DataAccess.Abstract;
using FreeShop.DataAccess.Abstract.EntityFramework.Context;
using FreeShop.Entities.Concrete;

namespace FreeShop.DataAccess.Concrete.EntityFramework
{
    public class ManagerRepository : EfRepositoryBase<Manager, FreeShopDbContext>, IManagerRepository
    {
        public Manager Login(string username, string password)
        {
            return this.Get(x=>x.UserName == username && x.Password == password);
        }

        public Manager GetByEmail(string email)
        {
            return Get(x => x.Email == email);
        }
    }
}
