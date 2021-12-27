using System;
using System.Collections.Generic;
using System.Text;
using FreeShop.Entities.Abstract;

namespace FreeShop.Entities.Concrete
{
    public class ProductPhoto : IEntity
    {
        //? isareti nullable anlamina gelir, referans tipli degiskenlerde kullanilmaz.
        public int ProductId { get; set; }
        public string PhotoPath { get; set; }

        public virtual Product Product { get; set; }
    }
}
