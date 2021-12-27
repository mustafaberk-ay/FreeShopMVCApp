using System;
using System.Collections.Generic;
using System.Text;
using FreeShop.Entities.Concrete;

namespace FreeShop.DataAccess.Abstract
{
    public interface IManagerRepository : IGenericRepository<Manager>
    {
        Manager Login(string username, string password);
        Manager GetByEmail(string email);
    }
}
