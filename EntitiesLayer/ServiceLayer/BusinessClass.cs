using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceLayer
{
    public class BusinessClass
    {
        MyRestaurantDBEntities context = new MyRestaurantDBEntities();

        public UserLoginControlModel UserLoginControl(string userName,string password)
        {
            Users usr = context.Users.FirstOrDefault(x => x.UserName == userName&&x.Password==password);
            UserLoginControlModel model = new UserLoginControlModel();
            if (usr != null)
            {
                model.LoginOk = true;
                model.Name = usr.Name;
                model.Surname = usr.Surname;
                model.UserType = usr.UserType;
            }
            else model.LoginOk = false;
            
            return model;
        }

        public List<MenuCategory> AllProdactCategory()
        {
            List<ProductTypes> categories = context.ProductTypes.ToList();
            List<MenuCategory> categories2 = new List<MenuCategory>();

            foreach (var item in categories)
            {
                categories2.Add(new MenuCategory() { Id = item.Id, ProductType = item.ProductTypeName });
            }
            return categories2;
        }

        public int EditMenuCategory(MenuCategory cat)
        {
            ProductTypes type = context.ProductTypes.FirstOrDefault(x => x.Id == cat.Id);
            type.ProductTypeName = cat.ProductType;
            return context.SaveChanges();
                
        }

        public int AddMenuCategory(string catName)
        {
            ProductTypes prd = new ProductTypes() {ProductTypeName=catName };
            ProductTypes control= context.ProductTypes.Add(prd);
            context.SaveChanges();
            if (control != null)
            {
                return 1;
            }
            else return 0;

        }

        public List<MenuProduct> AllProduct()
        {
            List<Products> products = context.Products.ToList();
            List<MenuProduct> products2 = new List<MenuProduct>();
            foreach (var item in products)
            {
                products2.Add(new MenuProduct()
                {
                    Id = item.Id,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    ProductTypeId = item.ProductTypeId,
                    ProductTypeName = item.ProductTypes.ProductTypeName
                });
            }

            return products2;
        }

        public int AddMenuProduct(MenuProduct product)
        {
            Products prd = new Products()
            {
                ProductName =product.ProductName,
                Price =product.Price,
                ProductTypeId =product.ProductTypeId
            };
            Products control=context.Products.Add(prd);

            context.SaveChanges();

            if (control != null) return 1;

            else return 0;

            
        }
    }
}