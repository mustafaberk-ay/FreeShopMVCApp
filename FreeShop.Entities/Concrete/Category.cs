using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using FreeShop.Entities.Abstract;

namespace FreeShop.Entities.Concrete
{
    public class Category : IEntity
    {
        public string CategoryName { get; set; }

        //Iliski kurdugumuz property'lerin tipi virtual'dir
        //Iliski kurdugmuz property'lere de Navigation Property denir.
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new HashSet<Product>();

        }
    }
}
