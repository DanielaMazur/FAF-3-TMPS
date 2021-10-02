# Topic: _Creational Design Patterns_

### Author: _Mazur Daniela_

---

## Objectives :

**1. Study the Creational Design Patterns**

**2. Implement them in real projects**

## Theory :

Design patterns are a group of predefined solutions that help in solving different common programming problems. Mainly Design Patterns are divided into 3 categories: Creational, Structural and Behavioral.
The Creational design patterns deal with object creation. The most common creational design patterns are listed bellow.

- Singleton
- Builder
- Prototype
- Factory Method
- Abstract Factory

## Implementation :

In this project I've used 3 creational design patterns: Singleton, Builder and Prototype.<br />
Singleton Design Pattern is used to ensure that you have a single instance of a specific object in the entire app. In this project, the Menu and Storage class are both singeltons, because a bakery shop can have only one menu and one storage. For the Menu class I implemented the Singleton pattern using static constructor implementation and for the Storage I've used Lazy implementation. Both of them are thread safe.<br />

```
    sealed class Menu
     {
          private static readonly Menu _menuInstance = new();
          private Menu() { }

          public static Menu Instance
          {
               get
               {
                    return _menuInstance;
               }
          }
     }
```

```
     sealed class Storage
     {
          private static readonly Lazy<Storage> _storageIntance = new(() => new Storage());
          private Storage() { }
          public static Storage Intance
          {
               get => _storageIntance.Value;
          }
     }
```

The Builder design patter was used for the Cake creation because a Cake can have a long list of optional ingredients and setting all of them in the constructor as nullable will make code to look messy and hard to read. For implementing the Builder pattern I created a class **CakeBuilder** which provides all necessary methods for creating a large number of different cakes. There are different implementations of the builder, but the one which is used in this project is allowing chaining builder methods because each method inside the Builder class returns _this_ (which is the builder instance), except the **Bake()** method which returns the concrete built object.<br />

```
     interface ICakeBuilder
     {
          ICakeBuilder AddDough(bool isGlutenFree = false);
          ICakeBuilder AddCream();
          ICakeBuilder AddCandiesDecorations(int units);
          ICakeBuilder AddFruits();
          ICakeBuilder AddChocolate(int units);
          Cake Bake();
     }
```

And the last Creational Pattern implemented in this project is Prototype. It was implemented using the IProduct interface which has the Clone method and each product implements it. So when a client wants to order a product he doesn't care about the concrete implementation, it uses the IProduct interface.

```
    Menu menu = Menu.Instance;

    menu.Items.AddRange(new List<IProduct>() {
        new CakeBuilder().AddDough().AddCream().AddChocolate(2).AddFruits().Bake(),
        new CakeBuilder().AddDough().AddFruits().AddDough(true).AddCandiesDecorations(5).Bake(),
        new CakeBuilder().AddFruits().AddCream().AddChocolate(3).AddCandiesDecorations(2).Bake(),
        new Bread(),
        new Bread(true)
    });

    List<IProduct> order = new();

    foreach (var menuItem in menu.Items)
    {
         if (menuItem.Ingredients.Exists(ingredient => ingredient.Type == IngredientTypeEnum.GlutenFreeDough))
         {
            order.Add(menuItem.Clone());
            System.Console.WriteLine(menuItem);
         }
    }
```
