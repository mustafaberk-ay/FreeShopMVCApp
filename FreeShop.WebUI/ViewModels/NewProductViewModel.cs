using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeShop.WebUI.ViewModels
{
    public class NewProductViewModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int CategoryId { get; set; }
        public string ShortDescription { get; set; }
    }
}
