using System.Threading.Tasks;

namespace BakeryShop.Interfaces
{
     interface IDeliveryService
     {
          public float Price { get; }
          public float MaxNumberOfUnits { get; }
     }
}
