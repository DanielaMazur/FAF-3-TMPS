using BakeryShop.Interfaces;

namespace BakeryShop
{
     class Ingredient : IProductPrototype<Ingredient>
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

          public Ingredient Clone()
          {
               return (Ingredient)this.MemberwiseClone();
          }
     }
}
