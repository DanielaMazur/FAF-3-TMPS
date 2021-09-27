using BakeryShop.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
     class Cake : IProduct, IProductPrototype<Cake>
     {
          public List<Ingredient> Ingredients { get; } = new();

          public Cake Clone()
          {
               return (Cake)this.MemberwiseClone();
          }

          public double GetPrice()
          {
               return Ingredients.Sum(ing => ing.Price * ing.Supply) * 1.2;
          }
     }
}
