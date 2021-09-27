using BakeryShop.Interfaces;
using System.Linq;

namespace BakeryShop
{
     class CakeBuilder : ICakeBuilder
     {
          private readonly Cake _cake = new();
          private readonly Storage _storage = Storage.Intance;
 
          public ICakeBuilder AddCandiesDecorations(int units = 1)
          {
               var candies = _storage.Ingredients.Single(ing => ing.Type == IngredientTypeEnum.Canides).Clone();
               candies.Supply = units;
               _cake.Ingredients.Add(candies);
               return this;
          }

          public ICakeBuilder AddCream()
          {
               var cream = _storage.Ingredients.Single(ing => ing.Type == IngredientTypeEnum.Cream).Clone();
               cream.Supply = 1;
               _cake.Ingredients.Add(cream);
               return this;
          }

          public ICakeBuilder AddDough(bool isGlutenFree = false)
          {
               var cackeDoughType = isGlutenFree ? IngredientTypeEnum.GlutenFreeCakeDough : IngredientTypeEnum.CakeDough;
               var cackeDough = _storage.Ingredients.Single(ing => ing.Type == cackeDoughType).Clone();
               cackeDough.Supply = 1;
               _cake.Ingredients.Add(cackeDough);
               return this;
          }

          public ICakeBuilder AddFruits()
          {
               var fruits = _storage.Ingredients.Single(ing => ing.Type == IngredientTypeEnum.Fruits).Clone();
               fruits.Supply = 1;
               _cake.Ingredients.Add(fruits);
               return this;
          }

          public ICakeBuilder AddChocolate(int units)
          {
               var chocolate = _storage.Ingredients.Single(ing => ing.Type == IngredientTypeEnum.Chocolate).Clone();
               chocolate.Supply = units;
               _cake.Ingredients.Add(chocolate);
               return this;
          }

          public Cake Bake()
          {
               foreach(var ingredient in _cake.Ingredients)
               {
                    var storageIngredient = _storage.Ingredients.Single(ing => ing.Type == ingredient.Type);

               }
               return _cake;
          }
     }
}
