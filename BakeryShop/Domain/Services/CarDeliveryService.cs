using BakeryShop.Interfaces;
using System.Collections.Generic;

namespace BakeryShop.Domain.Services
{
     class CarDeliveryService : IDeliveryService
     {
          public float Price { get; } = 10;
          public float MaxNumberOfUnits { get; } = 100;

          public void Deliver(List<IProduct> products)
          {
               System.Console.WriteLine("Car delivery service receive delivery order and is working on it.");
          }
     }
}
