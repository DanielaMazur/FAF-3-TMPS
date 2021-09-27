using System.Collections.Generic;

namespace BakeryShop
{
     sealed class Menu
     {
          public List<Cake> cakes { get; set; } = new();

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
