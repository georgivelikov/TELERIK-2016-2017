using System;

namespace State
{
    public class StartUp
    {
        public static void Main()
        {
            var developer = new Developer();
            developer.DoJob();

            developer.ReadDependencyInjection();
            developer.ReadDependencyInjection();
            developer.ReadDependencyInjection();
            developer.ReadDependencyInjection();
            developer.DoJob();

            developer.DrinkAlcohol();
            developer.DrinkAlcohol();
            developer.DrinkAlcohol();
            developer.DoJob();

            developer.ReadDependencyInjection();
            developer.ReadDependencyInjection();
            developer.ReadDependencyInjection();
            developer.ReadDependencyInjection();
            developer.ReadDependencyInjection();
            developer.ReadDependencyInjection();
            developer.ReadDependencyInjection();
            developer.ReadDependencyInjection();
            developer.ReadDependencyInjection();
            developer.DoJob();
        }
    }
}
