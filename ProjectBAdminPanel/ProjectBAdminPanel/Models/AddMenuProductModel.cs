using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBAdminPanel.Models
{
    public class AddMenuProductModel
    {
        public MenuProductModel Product { get; set; }
        public List<MenuCategoryModel> Categories { get; set; }
        
    }
}