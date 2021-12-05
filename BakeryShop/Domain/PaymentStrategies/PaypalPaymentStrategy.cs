using BakeryShop.Interfaces;
using System;

namespace BakeryShop.Domain.PaymentStrategies
{
     class PaypalPaymentStrategy : IPaymentStrategy
     {
          public void Pay(double amount)
          {
               Console.WriteLine("Please enter your account id");
               var accountId = Console.ReadLine();
               Console.WriteLine("Payment of " + amount + "$ is done using paypal account " + accountId);
          }
     }
}
