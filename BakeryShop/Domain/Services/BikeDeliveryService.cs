using BakeryShop.Interfaces;
using System.Collections.Generic;

namespace BakeryShop.Domain.Services
{
     class BikeDeliveryService : IDeliveryService
     {
          public float Price { get; } = 5;
          public float MaxNumberOfUnits { get; } = 5;

          public void Deliver(List<IProduct> products)
          {
               System.Console.WriteLine("Bike delivery service receive delivery order and is working on it.");
          }
     }
}
