using BakeryShop.Interfaces;
using System.Collections.Generic;

namespace BakeryShop
{
     sealed class Menu
     {
          public List<IProduct> Items { get; set; } = new();

          private static readonly Menu _menuInstance = new();
          private Menu() { }

          public static Menu Instance
          {
               get
               {
                    return _menuInstance;
               }
          }
     }
}
