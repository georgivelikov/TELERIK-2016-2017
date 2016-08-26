namespace Tasks_05_07
{
    using System;

    public class Start
    {
        public static void Main()
        {
            GenericList<int> genericList = new GenericList<int>();
            genericList.Add(1);
            genericList.Add(2);
            genericList.Add(3);
            genericList.Add(4);
            genericList.Add(5);
            genericList.Add(6);
            genericList.Add(7);
            genericList.Add(8);
            genericList.Add(9);
            genericList.Add(10);
            Console.WriteLine(genericList);

            genericList.Remove(7);
            Console.WriteLine(genericList); // see genericList.IndexOf() to check that indeces are correct
            genericList.Remove(321323); // message for non existing item

            Console.WriteLine("Min: " + genericList.Max);
            Console.WriteLine("Max: " + genericList.Min);
            genericList.Remove(1);
            genericList.Remove(10);
            Console.WriteLine("Nex Min: " + genericList.Max);
            Console.WriteLine("Nex Max: " + genericList.Min);
            Console.WriteLine("Everything is working with integers");
            Console.WriteLine();

            var stringGenericList = new GenericList<string>();
            stringGenericList.Add("bbb");
            stringGenericList.Add("ccc");
            stringGenericList.Add("aaa");
            stringGenericList.Add("kkk");
            stringGenericList.Add("zzz");
            stringGenericList.Add("qqq");
            Console.WriteLine(stringGenericList);
            stringGenericList.Remove("qqq");
            Console.WriteLine(stringGenericList);

            Console.WriteLine("Min: " + stringGenericList.Max);
            Console.WriteLine("Max: " + stringGenericList.Min);
            stringGenericList.Remove("aaa");
            stringGenericList.Remove("zzz");
            Console.WriteLine("New Min: " + stringGenericList.Max);
            Console.WriteLine("New Max: " + stringGenericList.Min);
            Console.WriteLine("Everything is working with strings");
            Console.WriteLine();

            var personGenericList = new GenericList<Person>();
            Person p1 = new Person("Ivan", 20);
            Person p2 = new Person("Georgi", 13);
            Person p3 = new Person("Stamat", 25);
            Person p4 = new Person("Mitko", 39);
            Person p5 = new Person("Petar", 2);
            Person p6 = new Person("Maria", 13);
            Person p7 = new Person("Stefan", 79);

            personGenericList.Add(p1);
            personGenericList.Add(p2);
            personGenericList.Add(p3);
            personGenericList.Add(p4);
            personGenericList.Add(p5);
            personGenericList.Add(p6);
            personGenericList.Add(p7);

            Console.WriteLine(personGenericList);
            personGenericList.Remove(p2);
            Console.WriteLine(personGenericList);

            Console.WriteLine("Oldest: " + personGenericList.Max);
            Console.WriteLine("Youngest: " + personGenericList.Min);
            personGenericList.Remove(p5);
            personGenericList.Remove(p7);
            Console.WriteLine("New Oldest: " + personGenericList.Max);
            Console.WriteLine("New Youngest: " + personGenericList.Min);
            Console.WriteLine("Everything is working with objects");
        }
    }
}
