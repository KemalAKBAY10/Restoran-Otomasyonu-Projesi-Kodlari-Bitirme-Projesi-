using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBAdminPanel.Models
{
    public class MenuProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int MenuCategoryId { get; set; }
        public string MenuCategoryName { get; set; }
        public decimal Price { get; set; }
    }
}