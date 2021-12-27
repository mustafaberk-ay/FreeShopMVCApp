using System;
using System.Collections.Generic;
using System.Text;
using FreeShop.Entities.Abstract;

namespace FreeShop.Entities.Concrete
{
    public class ProductComment : IEntity
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime CommentDate { get; set; }
        public string Comment { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
