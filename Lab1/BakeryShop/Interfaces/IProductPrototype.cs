namespace BakeryShop.Interfaces
{
     interface IProductPrototype<T>
     {
          public T Clone();
     }
}
