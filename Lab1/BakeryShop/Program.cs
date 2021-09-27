using System.Collections.Generic;

namespace BakeryShop
{
     class Program
     {
          static void Main(string[] args)
          {
               Storage storgae = Storage.Intance;

               storgae.Ingredients.AddRange(new List<Ingredient>() {
                    new(IngredientTypeEnum.Fruits, 5, 1),
                    new(IngredientTypeEnum.Canides, 10, 1),
                    new(IngredientTypeEnum.CakeDough, 7, 1),
                    new(IngredientTypeEnum.GlutenFreeCakeDough, 9, 5),
                    new(IngredientTypeEnum.Cream, 12, 2),
                    new(IngredientTypeEnum.Chocolate, 6, 3)
               });

               Menu menu = Menu.Instance;

               menu.cakes.AddRange(new List<Cake>() {
                    new CakeBuilder().AddDough().AddCream().AddChocolate(2).AddFruits().Bake(),
                    new CakeBuilder().AddDough().AddFruits().AddDough(false).AddCandiesDecorations(5).Bake(),
                    new CakeBuilder().AddFruits().AddCream().AddChocolate(3).AddCandiesDecorations(2).Bake()
               });

               List<Cake> order = new();

               foreach (var cake in menu.cakes)
               {
                    if (cake.Ingredients.Exists(ingredient => ingredient.Type == IngredientTypeEnum.Chocolate && ingredient.Supply == 2))
                    {
                         order.Add(cake.Clone());
                    }
               }
          }
     }
}
