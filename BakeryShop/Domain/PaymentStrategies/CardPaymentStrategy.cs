﻿using BakeryShop.Interfaces;
using System;

namespace BakeryShop.Domain.PaymentStrategies
{
     class CardPaymentStrategy : IPaymentStrategy
     {
          public void Pay(double amount)
          {
               Console.WriteLine("Please enter your card number");
               var cardNumber = Console.ReadLine();
               Console.WriteLine("Payment of " + amount + "$ is done using credit card " + cardNumber);
          }
     }
}
