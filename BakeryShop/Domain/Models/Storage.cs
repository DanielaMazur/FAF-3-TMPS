using System;
using System.Collections.Generic;

namespace BakeryShop.Domain.Models
{
     sealed class Storage
     {
          private static readonly Lazy<Storage> _storageIntance = new(() => new Storage());
          private Storage() { }
          private static List<Ingredient> _ingredients = new();
          public List<Ingredient> Ingredients
          {
               get => _ingredients;
               set => _ingredients = value;
          }
          public static Storage Intance
          {
               get => _storageIntance.Value;
          }
     }
}
