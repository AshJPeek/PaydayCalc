using PaydayCalc.Domain.Models;
using PaydayCalc.Domain.Ports;

namespace PaydayCalc.Domain;

public class LastFridayPaydayCalculator : IPaydayCalculator
{
    public List<string> Calculate(CalculationInput calculationInput)
    {
        var year = calculationInput.StartingDate.Year;
        var month = calculationInput.StartingDate.Month;
        
        DateOnly finalFriday = new DateOnly();

        var monthDays = DateTime.DaysInMonth(year, month);
        int i = 0;
        int numberOfMonths = 2;
        List<string> fridayPayday = new List<string>();

        while (i < numberOfMonths)
        {
            var currentDate = new DateOnly(year, month, monthDays);

            if (currentDate.DayOfWeek == DayOfWeek.Friday)
            {
                finalFriday = currentDate;
                fridayPayday.Add(finalFriday.ToString());
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
        return fridayPayday;
    }
}