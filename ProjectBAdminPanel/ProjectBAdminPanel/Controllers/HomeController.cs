using ProjectBAdminPanel.Models;
using ProjectBAdminPanel.MyRestaurantService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBAdminPanel.Controllers
{
    public class HomeController : BaseController
    {
        MyRestaurantServiceSoapClient MyService = new MyRestaurantServiceSoapClient();
        // GET: Home
        public ActionResult Index()
        {
            if (LogonUser() == 0)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (LogonUser() == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            UserLoginControlModel control = MyService.LoginUserControl(model.UserName, model.Password);
            if (control.LoginOk == true && control.UserType == 1)
            {
                LogonUserModel logonUser = new LogonUserModel() { Name = control.Name, Surname = control.Surname };
                Session["LogonUser"] = logonUser;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "Girmiş olduğunuz bilgiler hatalı.";
                return View();
            }

        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["LogonUser"] = null;
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult MenuCategory()
        {
            if (LogonUser() == 0)
            {
                return RedirectToAction("Login", "Home");
            }

            var list = MyService.AllMenuCategories();
            List<MenuCategoryModel> list2 = new List<MenuCategoryModel>();
            foreach (var item in list)
            {
                list2.Add(new MenuCategoryModel() { Id = item.Id, MenuCategory = item.ProductType });

            }
            MenuCategoryPageModel model = new MenuCategoryPageModel();
            model.Categories = list2;
            return View(model);
        }

        [HttpGet]
        public ActionResult EditCategory(int id, string categoryName)
        {
            if (LogonUser() == 0)
            {
                return RedirectToAction("Login", "Home");
            }


            MenuCategoryModel cat = new MenuCategoryModel() { Id = id, MenuCategory = categoryName };
            return View(cat);
        }

        [HttpPost]
        public ActionResult EditCategory(MenuCategoryModel cat)
        {
            int control = MyService.EditMenuCategory(new MyRestaurantService.MenuCategory() { Id = cat.Id, ProductType = cat.MenuCategory });
            if (control == 1)
            {
                TempData["Result"] = "Kategori düzenleme işlemi başarıyla gerçekleştirildi.";

            }
            else
            {
                TempData["Result"] = "Kategori düzenleme işlemi sırasında bir hatayla karşılaşıldı.Lütfen tekrar deneyiniz.";
            }
            return RedirectToAction("MenuCategory", "Home");
        }

        [HttpGet]
        public ActionResult AddNewMenuCategory()
        {
            if (LogonUser() == 0)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddNewMenuCategory(MenuCategoryModel model)
        {
            int control = MyService.AddMenuCategory(model.MenuCategory);
            if (control == 1)
            {
                TempData["Result"] = "Kategori ekleme işlemi başarıyla gerçekleştirildi.";
            }
            else
            {
                TempData["Result"] = "Kategori ekleme işlemi sırasında bir hatayla karşılaşıldı.Lütfen tekrar deneyiniz.";
            }
            return RedirectToAction("MenuCategory", "Home");
        }

        [HttpGet]
        public ActionResult MenuProduct()
        {
            if (LogonUser() == 0)
            {
                return RedirectToAction("Login", "Home");
            }

            var list = MyService.AllProducts();
            List<MenuProductModel> products = new List<MenuProductModel>();
            foreach (var item in list)
            {

                products.Add(new MenuProductModel()
                {
                    Id = item.Id,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    MenuCategoryId = item.ProductTypeId,
                    MenuCategoryName = item.ProductTypeName
                });
            }
            MenuProductPageModel model = new MenuProductPageModel() { Products = products };
            return View(model);
        }

        [HttpGet]
        public ActionResult AddNewProduct()
        {
            if (LogonUser() == 0)
            {
                return RedirectToAction("Login", "Home");
            }

            var list = MyService.AllMenuCategories();
            List<MenuCategoryModel> list2 = new List<MenuCategoryModel>();
            foreach (var item in list)
            {
                list2.Add(new MenuCategoryModel() { Id = item.Id, MenuCategory = item.ProductType });

            }
            AddMenuProductModel model = new AddMenuProductModel() { Categories = list2 };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddNewProduct(AddMenuProductModel model)
        {
           
            MyRestaurantService.MenuProduct prd = new MenuProduct()
            {
                ProductName = model.Product.ProductName,
                Price = model.Product.Price,
                ProductTypeId = model.Product.MenuCategoryId,
                ProductTypeName = model.Product.MenuCategoryName
            };
            int result = MyService.AddMenuProduct(prd);


            return RedirectToAction("MenuProduct","Home");
        }

        [HttpGet]
        public ActionResult MonthlySales()
        {
            if (LogonUser() == 0)
            {
                return RedirectToAction("Login", "Home");
            }

            return View();
        }
    }
}