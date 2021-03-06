using BakeryShop.Enums;
using BakeryShop.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryShop.Domain.Models
{
     class Bread : IProduct
     {
          public List<IIngredient> Ingredients { get; } = new();

          private readonly Storage _storage = Storage.Intance;

          public Bread(bool isGlutenFree = false)
          {
               var doughType = isGlutenFree ? IngredientTypeEnum.GlutenFreeDough : IngredientTypeEnum.Dough;
               var dough = _storage.Ingredients.Single(ing => ing.Type == doughType);
               dough.Supply = 1;
               Ingredients.Add(dough);
          }

          public IProduct Clone()
          {
               return (IProduct)this.MemberwiseClone();
          }

          public double GetPrice()
          {
               return Ingredients.Sum(ing => ing.Price * ing.Supply);
          }

          public override string ToString()
          {
               var ingredientString = new StringBuilder();

               foreach (var ingredient in Ingredients)
               {
                    ingredientString.Append($" {ingredient.Type},");
               }

               return $"Bread with{ingredientString}";
          }
     }
}
