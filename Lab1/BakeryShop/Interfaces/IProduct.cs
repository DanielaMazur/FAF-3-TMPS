using BakeryShop.Domain.Models;
using System.Collections.Generic;

namespace BakeryShop.Interfaces
{
     interface IProduct
     {
          List<Ingredient> Ingredients { get; }
          public double GetPrice();
          public IProduct Clone();
     }
}
