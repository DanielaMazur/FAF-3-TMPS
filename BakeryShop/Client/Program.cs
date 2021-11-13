using BakeryShop.Domain.Builder;
using BakeryShop.Domain.Models;
using BakeryShop.Enums;
using BakeryShop.Interfaces;
using System.Collections.Generic;

namespace BakeryShop.Client
{
     class Program
     {
          static void Main(string[] args)
          {
               Storage storgae = Storage.Intance;

               storgae.Ingredients.AddRange(new List<Ingredient>() {
                    new(IngredientTypeEnum.Fruits, 5, 1),
                    new(IngredientTypeEnum.Canides, 10, 1),
                    new(IngredientTypeEnum.Dough, 7, 1),
                    new(IngredientTypeEnum.GlutenFreeDough, 9, 5),
                    new(IngredientTypeEnum.Cream, 12, 2),
                    new(IngredientTypeEnum.Chocolate, 6, 3)
               });

               Menu menu = Menu.Instance;

               menu.Items.AddRange(new List<IProduct>() {
                    new CakeBuilder().AddDough().AddCream().AddChocolate(2).AddFruits().Bake(),
                    new CakeBuilder().AddDough().AddFruits().AddDough(true).AddCandiesDecorations(5).Bake(),
                    new CakeBuilder().AddFruits().AddCream().AddChocolate(3).AddCandiesDecorations(2).Bake(), 
                    new Bread(),
                    new Bread(true)
               });

               List<IProduct> order = new();

               foreach (var menuItem in menu.Items)
               {
                    if (menuItem.Ingredients.Exists(ingredient => ingredient.Type == IngredientTypeEnum.GlutenFreeDough))
                    {
                         order.Add(menuItem.Clone());
                         System.Console.WriteLine(menuItem);
                    }
               }
          }
     }
}
