using BakeryShop.Domain.Models;

namespace BakeryShop.Interfaces
{
     interface ICakeBuilder
     {
          ICakeBuilder AddDough(bool isGlutenFree = false);
          ICakeBuilder AddCream();
          ICakeBuilder AddCandiesDecorations(int units);
          ICakeBuilder AddFruits();
          ICakeBuilder AddChocolate(int units);
          Cake Bake();
     }
}
