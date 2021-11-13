using BakeryShop.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop.Client
{
     class Program
     {
          static void Main(string[] args)
          {
               IBakeryShop _bakeryShop = new Domain.Models.BakeryShop();

               var menuItems = _bakeryShop.GetMenuItems();

               List<IProduct> orderdProducts = new();

               foreach (var item in menuItems)
               {
                    if (item.Item.GetPrice() < 50)
                    {
                         System.Console.WriteLine("you have ordered =>" + item.Item.GetType());
                         orderdProducts.Add(_bakeryShop.OrderMenuItem(item.Id));
                    }
               }

               _bakeryShop.GetDelivery(orderdProducts);
          }
     }
}
