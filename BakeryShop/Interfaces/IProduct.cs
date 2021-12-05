using System.Collections.Generic;

namespace BakeryShop.Interfaces
{
     interface IProduct
     {
          List<IIngredient> Ingredients { get; }
          public double GetPrice();
          public IProduct Clone();
     }
}
