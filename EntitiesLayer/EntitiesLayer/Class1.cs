using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Class1
    {
        MyRestaurantDBEntities context = new MyRestaurantDBEntities();
        public Class1()
        {
           //context= new MyRestaurantDBEntities();
        }

        public int getUser(string userName)
        {
            Users user = context.Users.FirstOrDefault(x => x.UserName == userName);
            return user.UserType;
        }
    }
}
