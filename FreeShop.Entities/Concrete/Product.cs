using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using FreeShop.Entities.Abstract;

namespace FreeShop.Entities.Concrete
{
    public class Product : IEntity
    {
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public int? Discount { get; set; }
        public string ShortDescription { get; set; }
        public int? CategoryId { get; set; }


        public virtual Category Category { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotos{ get; set; }

        public virtual ICollection<ProductComment> ProductComments { get; set; }

        public Product()
        {
            ProductPhotos = new HashSet<ProductPhoto>();
            ProductComments = new HashSet<ProductComment>();
        }
    }
}
