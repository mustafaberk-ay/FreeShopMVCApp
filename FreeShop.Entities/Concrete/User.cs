using System;
using System.Collections.Generic;
using System.Text;
using FreeShop.Entities.Abstract;

namespace FreeShop.Entities.Concrete
{
    public class User : IEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhotoPath { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<ProductComment> Comments { get; set; }

        public User()
        {
            Comments = new HashSet<ProductComment>();
        }
    }
}
