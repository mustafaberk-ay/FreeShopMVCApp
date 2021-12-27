using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeShop.WebUI.Helpers
{
    public static class RandomNameGenerator
    {
        public static string GenerateFileName(string extension)
        {
            return Guid.NewGuid().ToString().Replace("-", "") + extension;
        }
    }
}
