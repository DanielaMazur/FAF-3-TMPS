using BakeryShop.Domain.PaymentStrategies;
using BakeryShop.Interfaces;
using System;
using System.Collections.Generic;

namespace BakeryShop.Client
{
     class Program
     {
          static void Main(string[] args)
          {
               IBakeryShop _bakeryShop = new Domain.Models.BakeryShop();

               var menuItems = _bakeryShop.GetMenuItems();

               Console.WriteLine("Hi, this is the menu of our Backery Shop");
               foreach (var item in menuItems)
               {
                    Console.WriteLine(item);
               }

               Console.WriteLine("Please choose items one by one by inserting item id, and then press enter");
               Console.WriteLine("When you finished ordering write ORDER");


               List<IProduct> orderdProducts = ProcessOrder(_bakeryShop);
               double orderPrice = GetOrderListPrice(orderdProducts);
               _bakeryShop.GetDelivery(orderdProducts);
               ProcessPayment(orderPrice);
          }

          private static List<IProduct> ProcessOrder(IBakeryShop _bakeryShop)
          {
               List<IProduct> orderdProducts = new();

               while (true)
               {
                    var currentLine = Console.ReadLine();
                    if (currentLine == "ORDER")
                    {
                         if (orderdProducts.Count == 0)
                         {
                              Console.WriteLine("Your oder should have at least one item");
                              continue;
                         }
                         return orderdProducts;
                    }
                    var isValidInput = int.TryParse(currentLine, out int parsedResult);
                    if (!isValidInput)
                    {
                         Console.WriteLine("Please introduce a number");
                         continue;
                    }
                    var orderedItem = _bakeryShop.OrderMenuItem(parsedResult);
                    if (orderedItem == null)
                    {
                         Console.WriteLine("You introduced an invalid item id, please choose once again");
                         continue;
                    }
                    orderdProducts.Add(orderedItem);
               }

          }

          private static double GetOrderListPrice(List<IProduct> orderedList)
          {
               double orderPrice = 0;
               foreach (var product in orderedList)
               {
                    orderPrice += product.GetPrice();
               }
               return orderPrice;
          }

          private static void ProcessPayment(double orderPrice)
          {

               Console.WriteLine("Choose your payment method by order number");
               Console.WriteLine("1. Card Payment");
               Console.WriteLine("2. Paypal Payment");
               Console.WriteLine("3. Cash payment");

               var paymentMethod = Console.ReadLine();
               int parsedResult;
               var isValidPaymentMethod = int.TryParse(paymentMethod, out parsedResult);
               while (!isValidPaymentMethod)
               {
                    paymentMethod = Console.ReadLine();
                    isValidPaymentMethod = int.TryParse(paymentMethod, out parsedResult);
               }

               PaymentContext pc = new();

               switch (parsedResult)
               {
                    case 1: pc.SetStrategy(new CardPaymentStrategy()); pc.ExecuteStrategy(orderPrice); break;
                    case 2: pc.SetStrategy(new PaypalPaymentStrategy()); pc.ExecuteStrategy(orderPrice); break;
                    case 3: pc.SetStrategy(new CashPaymentStrategy()); pc.ExecuteStrategy(orderPrice); break;
                    default: Console.WriteLine("You introduced an invalid payment strategy"); break;
               }
          }
     }
}
