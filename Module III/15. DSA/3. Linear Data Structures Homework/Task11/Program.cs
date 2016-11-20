using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    public class Program
    {
        public static void Main()
        {
            ListItem<int> item1 = new ListItem<int>(3);
            ListItem<int> item2 = new ListItem<int>(30);
            ListItem<int> item3 = new ListItem<int>(12);
            ListItem<int> item4 = new ListItem<int>(300);

            LinkedList<int> list = new LinkedList<int>();
            list.AddItem(item1);
            list.AddItem(item2);
            list.AddItem(item3);
            list.AddItem(item4);

            foreach (var item in list)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
