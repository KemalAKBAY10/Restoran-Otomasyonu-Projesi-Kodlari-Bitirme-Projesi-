using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLayer.Models
{
    public class UserLoginControlModel
    {
        public bool LoginOk { get; set; }
        public int UserType { get; set; }
        public string  Name { get; set; }
        public string Surname { get; set; }
    }
}