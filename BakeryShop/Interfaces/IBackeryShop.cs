using BakeryShop.Domain.Models;
using System.Collections.Generic;

namespace BakeryShop.Interfaces
{
     interface IBackeryShop
     {
          List<MenuItem> GetMenuItems();
          IProduct OrderMenuItem(int id);
     }
}
