using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiceLayer
{
    /// <summary>
    /// Summary description for MyRestaurantService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyRestaurantService : System.Web.Services.WebService
    {

        BusinessClass business = new BusinessClass();

        [WebMethod]
        public UserLoginControlModel LoginUserControl(string userName, string password)
        {
            return business.UserLoginControl(userName, password);
        }

        [WebMethod]
        public List<MenuCategory> AllMenuCategories()
        {
            return business.AllProdactCategory();
        }

        [WebMethod]
        public int EditMenuCategory(MenuCategory cat)
        {
            return business.EditMenuCategory(cat); ;
        }

        [WebMethod]
        public int AddMenuCategory(string catName)
        {
            return business.AddMenuCategory(catName);
        }

        [WebMethod]
        public List<MenuProduct> AllProducts()
        {
            return business.AllProduct();
        }

        [WebMethod]
        public int AddMenuProduct(MenuProduct prd)
        {
            return business.AddMenuProduct(prd);
        }
        
        
    }
}
