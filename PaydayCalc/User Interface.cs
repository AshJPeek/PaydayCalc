using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaydayCalc
{
    public static class UserInterface
    {
        public static void Menu()
        {
            Console.WriteLine("Welcome to the pay day calculator\n");

            Console.WriteLine("Please input the year you wish to use");
            var year = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please input the month you wish to use");
            var month = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Please input the Pay Day calculation you would like to use!\n");
            Console.WriteLine("""
                              1. A fixed date calculator (weekend days will be paid on the preceeding friday)
                              2. A final business day calculator
                              3. A final friday of the month calculator
                              4. Every 4 weeks
                              """);
            string chosenCalc = Console.ReadLine();
            Console.Clear();

            switch(chosenCalc)
            {
                case "1":
                    Console.WriteLine("Please input the fixed day for payment");
                    var chosenDate = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("Fixed Date Calculator");
                    List<string> payFixedDay = PayDayCalculators.FixedDate.FixedDateCalc(year, month, chosenDate);
                    foreach(string payDay in payFixedDay)
                    {
                        Console.WriteLine(payDay);

                    }
                    break;
                case "2":
                    Console.WriteLine("Final Business Day Calculator\n");
                    List<string> payBusinessDay = PayDayCalculators.LastBusinessDay.LastBusinessDayCalc(year, month);
                    foreach (string payDay in payBusinessDay)
                    {
                        Console.WriteLine(payDay);
                    }
                    break;

                case "3":
                    Console.WriteLine("Final friday of the month calculator");
                    List<string> fridayPayday = PayDayCalculators.LastFriday.LastFridayCalc(year, month);
                    foreach(string friday in fridayPayday)
                    {
                        Console.WriteLine(friday);
                    }
                    break;

                case "4":
                    Console.WriteLine("Every 4 weeks calculator");
                    Console.WriteLine("Please input the day you wish to calculate from");
                    var day = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                    List<string> fourWeeksPayday = PayDayCalculators.FourWeeks.FourWeeksCalc(year, month, day);
                    foreach(string week in fourWeeksPayday)
                    {
                        Console.WriteLine(week);
                    }
                    break;
            }
                
        }
    }
}
