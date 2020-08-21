using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBAdminPanel.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            
        }
        protected int LogonUser()
        {
            if (Session["LogonUser"] == null) return 0;
            else
            {
                
                return 1;
            } 
        }
    }
}