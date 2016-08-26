namespace Task_11
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            Footballer footballer = new Footballer("Gareth Bale", 11);

            var attributes = typeof(Footballer).GetCustomAttributes(false);

            Console.WriteLine(attributes[0]);
            Console.WriteLine(footballer);
        }
    }
}
