using System;

namespace TESTConsoleApp1mosh
{
    /// <summary>
    /// ABSTRACT FACTORY DESIGN PATTERN
    ///
    /// from https://exceptionnotfound.net/tag/design-patterns/
    ///
    /// </summary>

    public class Client
    {
        private static void Main(string[] args)
        {
            RecipeFactory rec = new AdultFactory();

            var adultSandwich = rec.CreateSandwich();
            var adultDessert = rec.CreateDessert();

            Console.WriteLine("Sandwich " + adultSandwich.GetType().Name);
            Console.WriteLine("Dessert " + adultDessert.GetType().Name);

            Console.ReadLine();
        }
    }

    public abstract class RecipeFactory
    {
        public abstract Sandwich CreateSandwich();

        public abstract Dessert CreateDessert();
    }

    public class AdultFactory : RecipeFactory
    {
        public override Dessert CreateDessert()
        {
            return new StickyToffee();
        }

        public override Sandwich CreateSandwich()
        {
            return new BLT();
        }
    }

    public class Kids : RecipeFactory
    {
        public override Dessert CreateDessert()
        {
            return new KidsStickyToffee();
        }

        public override Sandwich CreateSandwich()
        {
            return new KidsBLT();
        }
    }

    //Sandwich related
    public abstract class Sandwich { }

    public class BLT : Sandwich { }

    public class KidsBLT : Sandwich { }

    //Dessert Related
    public abstract class Dessert { }

    public class StickyToffee : Dessert { }

    public class KidsStickyToffee : Dessert { }
}