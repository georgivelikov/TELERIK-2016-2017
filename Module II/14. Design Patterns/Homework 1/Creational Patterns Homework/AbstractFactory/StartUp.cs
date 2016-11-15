using System;
using AbstractFactory.Contracts;
using AbstractFactory.Models.Factories;

namespace AbstractFactory
{
    public class StartUp
    {
        public static void Main()
        {
            IVehicleFactory americanFactory = new AmericaFactory();
            IVehicleFactory japaneseFactory = new JapaneseFactory();

            ICar americanCar = americanFactory.CreateCar();
            IMotorcycle americanMotorcycle = americanFactory.CreateMotorcycle();

            ICar japaneseCar = japaneseFactory.CreateCar();
            IMotorcycle japaneseMotorcycle = japaneseFactory.CreateMotorcycle();

            Console.WriteLine("American vehicles:");
            Console.WriteLine(americanCar);
            Console.WriteLine(americanMotorcycle);
            Console.WriteLine("Japanese vehicles:");
            Console.WriteLine(japaneseCar);
            Console.WriteLine(japaneseMotorcycle);
        }
    }
}
