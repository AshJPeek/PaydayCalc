using PaydayCalc.Domain;
using PaydayCalc.Domain.Models;

namespace PaydayCalc.Adapters.Console
{
    public static class UserInterface
    {
        public static void Menu()
        {
            System.Console.WriteLine("Welcome to the pay day calculator\n");
            
            System.Console.WriteLine("What is your payday schedule?");
            System.Console.WriteLine("1 = Fixed date every month");
            System.Console.WriteLine("2 = Every four weeks");
            System.Console.WriteLine("3 = Last business day of the month");
            System.Console.WriteLine("4 = Last friday of the month");

            var answerInteger = int.Parse(System.Console.ReadLine() ?? "1");
            var answer = (PaydayCalculatorType)answerInteger;
            System.Console.Clear();

            var paydayCalculatorFactory = new PaydayCalculatorFactory();
            var paydayCalculator = paydayCalculatorFactory.Create(answer);
            var paydays = paydayCalculator.Calculate(new CalculationInput
            {
                StartingDate = DateTime.UtcNow,
                ChosenPayday = 23
            });
            
            foreach(var payDay in paydays)
            {
                System.Console.WriteLine(payDay);
            }
        }
    }
}
