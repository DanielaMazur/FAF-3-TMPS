using BakeryShop.Interfaces;

namespace BakeryShop.Domain.Models
{
     class MenuItem
     {
          public int Id { get; }
          public IProduct Item { get; }
          public MenuItem(int id, IProduct product)
          {
               Id = id;
               Item = product;
          }
     }
}
