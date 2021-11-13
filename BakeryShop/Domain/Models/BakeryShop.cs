using BakeryShop.Domain.Builder;
using BakeryShop.Domain.Services;
using BakeryShop.Enums;
using BakeryShop.Interfaces;
using System.Collections.Generic;

namespace BakeryShop.Domain.Models
{
     class BakeryShop : IBakeryShop
     {
          private Menu _menu;
          private Storage _storage;
          private ProxyDeliveryService _deliveryService;
          public BakeryShop()
          {
               _storage = Storage.Intance;

               _storage.Ingredients.AddRange(new List<IIngredient>() {
                    new Ingredient(IngredientTypeEnum.Fruits, 5, 1),
                    new Ingredient(IngredientTypeEnum.Canides, 10, 1),
                    new Ingredient(IngredientTypeEnum.Dough, 7, 1),
                    new Ingredient(IngredientTypeEnum.GlutenFreeDough, 9, 5),
                    new Ingredient(IngredientTypeEnum.Cream, 12, 2),
                    new Ingredient(IngredientTypeEnum.Chocolate, 6, 3)
               });

               _menu = Menu.Instance;

               var availableProducts = new List<IProduct>() {
                    new CakeBuilder().AddDough().AddCream().AddSecreteIngredient().AddChocolate(2).AddFruits().Bake(),
                    new CakeBuilder().AddDough().AddFruits().AddDough(true).AddCandiesDecorations(5).Bake(),
                    new CakeBuilder().AddFruits().AddCream().AddChocolate(3).AddCandiesDecorations(2).Bake(),
                    new Bread(),
                    new Bread(true)
               };

               foreach(var product in availableProducts)
               {
                    _menu.Items.Add(new MenuItem(_menu.Items.Count, product));
               }

               _deliveryService = new();
          }

          public List<MenuItem> GetMenuItems()
          {
               return _menu.Items;
          }

          public IProduct OrderMenuItem(int id)
          {
               var orderedItem = _menu.Items.Find(item => item.Id == id);
               if(orderedItem == null)
               {
                    return null;
               }

               return orderedItem.Item.Clone();
          }

          public void GetDelivery(List<IProduct> order)
          {
               _deliveryService.Deliver(order);
          }
     }
}
