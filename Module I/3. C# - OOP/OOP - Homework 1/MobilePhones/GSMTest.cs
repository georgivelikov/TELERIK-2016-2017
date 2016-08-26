namespace MobilePhones
{
    using System;
    using System.Globalization;
    using System.Threading;

    using MobilePhones.Enums;
    using MobilePhones.Objects;

    public class GSMTest
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("En-GB");

            GSM applePhone = new GSM(
                "iPhone 6s",
                "Apple",
                599.99m,
                "Ivan Petrov",
                new Battery("Non-removable Apple Battery", 240, 14, BatteryType.Li_Po),
                new Display(4.7, 16000000));

            GSM samsungPhone = new GSM(
                "Galaxy 7",
                "Samsung",
                569.99m,
                "Stamat Stamatov",
                new Battery("Non-removable Samsung Battery", 200, 14, BatteryType.Li_Ion),
                new Display(5.1, 16000000));

            GSM huaweiPhone = new GSM(
                "Honor V8",
                "Huawei",
                269.99m,
                "Stefan Georgiev",
                new Battery("Huawei Battery", 200, 14, BatteryType.NiCd),
                new Display(5.7, 15000000));

            GSM[] phones = { applePhone, samsungPhone, huaweiPhone };

            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
                Console.WriteLine();
            }

            Console.WriteLine(GSM.IPhone4S);

            Console.WriteLine();
            Call callOne = new Call(new DateTime(2016, 12, 31, 4, 32, 10), "0899 753 123", 60);
            Call callTwo = new Call(new DateTime(2015, 02, 12, 14, 12, 43), "0894 771 423", 120);
            Call callThree = new Call(new DateTime(2016, 5, 3, 11, 38, 00), "0878 333 623", 30);

            applePhone.AddCall(callOne);
            applePhone.AddCall(callTwo);
            applePhone.AddCall(callThree);

            Console.WriteLine(applePhone.PrintCallHistory());
            Console.WriteLine();
            Console.WriteLine("Total price: {0:0.00} USD", applePhone.CalculateTotalPrice());

            applePhone.DeleteCall(callTwo);
            Console.WriteLine();
            Console.WriteLine("Total price without the longest call: {0:0.00} USD", applePhone.CalculateTotalPrice());

            Console.WriteLine();
            applePhone.ClearHistory();
            Console.WriteLine(applePhone.PrintCallHistory());
        }
    }
}
