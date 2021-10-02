using BakeryShop.Enums;
 
namespace BakeryShop
{
     class Ingredient
     {
          public IngredientTypeEnum Type { get; }
          public float Price { get; }
          public int Supply { get; set; }

          public Ingredient(IngredientTypeEnum type, float price, int supply)
          {
               Type = type;
               Price = price;
               Supply = supply;
          }
     }
}
