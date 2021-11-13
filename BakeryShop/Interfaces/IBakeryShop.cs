using BakeryShop.Domain.Models;
using System.Collections.Generic;

namespace BakeryShop.Interfaces
{
     interface IBakeryShop
     {
          List<MenuItem> GetMenuItems();
          IProduct OrderMenuItem(int id);
          void GetDelivery(List<IProduct> order);
     }
}
