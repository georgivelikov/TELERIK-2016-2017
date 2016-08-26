using System;

public class Program
{
    public static void Main()
    {
        string name = Console.ReadLine();
        string address = Console.ReadLine();
        string tel = Console.ReadLine();
        string fax = Console.ReadLine();
        string mail = Console.ReadLine();
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string personalPhone = Console.ReadLine();

        Console.WriteLine(name);
        Console.WriteLine("Address: {0}", address);
        Console.WriteLine("Tel. {0}", tel);
        if (fax == string.Empty)
        {
            Console.WriteLine("Fax: (no fax)");
        }
        else
        {
            Console.WriteLine("Fax: {0}", fax);
        }

        Console.WriteLine("Web site: {0}", mail);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", firstName, lastName, age, personalPhone);
    }
}

