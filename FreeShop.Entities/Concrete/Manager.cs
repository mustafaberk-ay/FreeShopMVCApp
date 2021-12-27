using System;
using System.Collections.Generic;
using System.Text;
using FreeShop.Entities.Abstract;

namespace FreeShop.Entities.Concrete
{
    public class Manager : IEntity
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhotoPath { get; set; }
        public string Email { get; set; }
    }
}
