using BakeryShop.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryShop.Domain.Models
{
     class Cake : IProduct
     {
          public List<IIngredient> Ingredients { get; } = new();

          public IProduct Clone()
          {
               return (IProduct)this.MemberwiseClone();
          }

          public double GetPrice()
          {
               return Ingredients.Sum(ing => ing.Price * ing.Supply) * 1.2;
          }

          public override string ToString()
          {
               var ingredientString = new StringBuilder();

               foreach (var ingredient in Ingredients)
               {
                    ingredientString.Append($" {ingredient.Type},");
               }

               return $"Cake with{ingredientString}";
          }
     }
}
