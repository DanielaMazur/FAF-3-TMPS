using BakeryShop.Enums;

namespace BakeryShop.Interfaces
{
     interface IIngredient
     {
          IngredientTypeEnum Type { get; }
          float Price { get; }
          int Supply { get; set; }
     }
}
