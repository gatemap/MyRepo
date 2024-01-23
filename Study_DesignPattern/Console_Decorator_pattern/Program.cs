using System;

namespace Console_Decorator_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Beverage beverage = new Espresso();
            Console.WriteLine($"{beverage.GetDescription()} ${beverage.Cost()}");

            Beverage beverage2 = new HouseBlend();
            beverage2 = new Mocha(beverage2);
            Console.WriteLine($"{beverage2.GetDescription()} ${beverage2.Cost()}");
        }
    }

    public abstract class Beverage
    {
        public string description = "";

        public string GetDescription()
        {
            return description;
        }

        public abstract double Cost();
    }

    public abstract class CondimentDecorator : Beverage
    {
        public abstract string GetDescription();
    }

    public class Espresso : Beverage
    {
        public Espresso()
        {
            description = "Espresso";
        }

        public override double Cost()
        {
            return 1.99;
        }
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            description = "House blend coffee";
        }

        public override double Cost()
        {
            return .89;
        }
    }

    public class Mocha : CondimentDecorator
    {
        Beverage beverage;

        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string GetDescription()
        {
            return beverage.GetDescription() + ", mocha";
        }

        public override double Cost()
        {
            return .20 + beverage.Cost();
        }
    }
}

