using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreeShop.WebUI.ViewModels
{
    public class AdminViewModel
    {
        [Required(ErrorMessage = "Kullanici adi bos birakilamaz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Parola bos birakilamaz")]
        [MinLength(3, ErrorMessage = "Parola 3 karakterden az olamaz")]
        public string Password { get; set; }

        public bool IsChecked { get; set; }
    }
}
