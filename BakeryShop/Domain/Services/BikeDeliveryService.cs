using BakeryShop.Interfaces;

namespace BakeryShop.Domain.Services
{
     class BikeDeliveryService : IDeliveryService
     {
          public float Price { get; } = 5;
          public float MaxNumberOfUnits { get; } = 5;
     }
}
