# Topic: _Structural Design Patterns_

### Author: _Mazur Daniela_

---

## Objectives :

**1. Study the Structural Design Patterns**

**2. Implement them in real projects**

## Theory :

Design patterns are a group of predefined solutions that help in solving different common programming problems. Mainly Design Patterns are divided into 3 categories: Creational, Structural and Behavioral.
Structural design patterns are concerned with how classes and objects can be composed, to form larger structures.

- _Adapter Pattern_
  Adapting an interface into another according to client expectation.

- _Bridge Pattern_
  Separating abstraction (interface) from implementation.

- _Composite Pattern_
  Allowing clients to operate on hierarchy of objects.

- _Decorator Pattern_
  Adding functionality to an object dynamically.

- _Facade Pattern_
  Providing an interface to a set of interfaces.

- _Flyweight Pattern_
  Reusing an object by sharing it.

- _Proxy Pattern_
  Representing another object.

References => https://www.javatpoint.com/structural-design-patterns

## Implementation :

In this project I've used 3 structural design patterns: Facade, Bridge and Proxy.<br/>
Facade is a structural design pattern that provides a simplified interface to a library, a framework, or any other complex set of classes. In this case the Facade class is represented by the BakeryShop class. Client communicates with the Facade class using the IBakeryShop interface. Using this pattern, client doesn't need to know anything about the BakeryShop system except the methods which are exposed by the BakeryShop class. In this way, Facade Pattern simplifies the interaction with our system.<br/>
The bellow snippet can be found [here](../BakeryShop/Interfaces/IBakeryShop.cs)

```
    interface IBakeryShop
    {
        List<MenuItem> GetMenuItems();
        IProduct OrderMenuItem(int id);
        void GetDelivery(List<IProduct> order);
    }
```

Bridge is a structural design pattern that lets you split a large class or a set of closely related classes into two separate hierarchies—abstraction and implementation—which can be developed independently of each other. In this case Bridge design pattern is represented by the IProduct and IIngredient relationships. In this way we completely separated the this set of closely related classes into 2 hierarchies.

The bellow snippet can be found [here](../BakeryShop/Interfaces)

```
    interface IIngredient
    {
        IngredientTypeEnum Type { get; }
        float Price { get; }
        int Supply { get; set; }
    }

    interface IProduct
    {
        List<IIngredient> Ingredients { get; }
        public double GetPrice();
        public IProduct Clone();
    }
```

Using this interfaces we can create several concrete implementations, like Cake and Bread which extend IProduct or Ingredient and SecretIngredient which extend IIngredient.<br/>
Proxy is a structural design pattern that lets you provide a substitute or placeholder for another object. A proxy controls access to the original object, allowing you to perform something either before or after the request gets through to the original object. In the case of our system the proxy is used to control access to the delivery services

The bellow snippet can be found [here](../BakeryShop/Domain/Services/ProxyDeliveryService.cs)

```
  class ProxyDeliveryService
     {
          IDeliveryService _carDeliveryService = new CarDeliveryService();
          IDeliveryService _bikeDeliveryService = new BikeDeliveryService();

          public void Deliver(List<IProduct> products)
          {
               if(products.Count > 5)
               {
                    _carDeliveryService.Deliver(products);
                    return;
               }
               _bikeDeliveryService.Deliver(products);
          }
     }
```
