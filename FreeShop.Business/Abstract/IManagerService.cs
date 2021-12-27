using System;
using System.Collections.Generic;
using System.Text;
using FreeShop.Entities.Concrete;

namespace FreeShop.Business.Abstract
{
    public interface IManagerService : IGenericService<Manager>
    {
        Manager Login(string username, string password);
        Manager GetByEmail(string email);
    }
}
