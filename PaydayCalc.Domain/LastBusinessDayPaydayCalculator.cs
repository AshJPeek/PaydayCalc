using PaydayCalc.Domain.Models;
using PaydayCalc.Domain.Ports;

namespace PaydayCalc.Domain;

public class LastBusinessDayPaydayCalculator : IPaydayCalculator
{
    public List<string> Calculate(CalculationInput calculationInput)
    {
        var year = calculationInput.StartingDate.Year;
        var month = calculationInput.StartingDate.Month;
        
        DateOnly finalBusinessDay = new DateOnly();
        List<string> finalBusinessPayday = new List<string>();                              
        var monthDays = DateTime.DaysInMonth(year, month);
        var i = 0;
        var numberOfMonths = 2;

        while (i < numberOfMonths)
        {
            var currentDate = new DateOnly(year, month, monthDays);
            if (currentDate.DayOfWeek < DayOfWeek.Saturday && currentDate.DayOfWeek > DayOfWeek.Sunday)
            {
                finalBusinessDay = currentDate;
                finalBusinessPayday.Add(finalBusinessDay.ToString());
                i++;
                month++;
                if (month > 12)
                {
                    year++;
                }

                if (month == 13)
                {
                    month = 1;
                }

                monthDays = DateTime.DaysInMonth(year, month);
            }
            else
            {
                monthDays--;
            }
        }
        return finalBusinessPayday;
    }
}