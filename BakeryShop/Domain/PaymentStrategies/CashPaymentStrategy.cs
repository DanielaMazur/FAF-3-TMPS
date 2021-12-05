using BakeryShop.Interfaces;
using System;

namespace BakeryShop.Domain.PaymentStrategies
{
     class CashPaymentStrategy : IPaymentStrategy
     {
          public void Pay(double amount)
          {
               Console.WriteLine("Cash payment of " + amount + "$ executed successfully");
          }
     }
}
