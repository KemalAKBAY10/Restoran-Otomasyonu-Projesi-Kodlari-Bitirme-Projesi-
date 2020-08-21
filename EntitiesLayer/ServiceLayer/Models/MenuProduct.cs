using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLayer.Models
{
    public class MenuProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public decimal Price { get; set; }
    }
}