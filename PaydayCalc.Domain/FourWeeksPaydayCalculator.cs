using PaydayCalc.Domain.Models;
using PaydayCalc.Domain.Ports;

namespace PaydayCalc.Domain;

public class FourWeeksPaydayCalculator : IPaydayCalculator
{
    public List<string> Calculate(CalculationInput calculationInput)
    {
        DateOnly currentDay = new DateOnly(calculationInput.StartingDate.Year, calculationInput.StartingDate.Month, calculationInput.StartingDate.Day);
        DateOnly payDay = new DateOnly();
        List<string> yearlyPayday = new List<string>();
        int i = 0;
        int numberOfWeeks = 6;

        while (i != numberOfWeeks)
        {
            currentDay = currentDay.AddDays(28);
            i++;
            payDay = currentDay;
            yearlyPayday.Add(payDay.ToString());
        }

        return yearlyPayday;

    }
}