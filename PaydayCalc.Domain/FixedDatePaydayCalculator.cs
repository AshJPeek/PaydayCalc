using PaydayCalc.Domain.Models;
using PaydayCalc.Domain.Ports;

namespace PaydayCalc.Domain;

public class FixedDatePaydayCalculator : IPaydayCalculator
{
    public List<string> Calculate(CalculationInput calculationInput)
    {
        DateOnly fixedDate = new DateOnly();
        List<string> fixedDatePayday = new List<string>();
        var year = calculationInput.StartingDate.Year;
        var month = calculationInput.StartingDate.Month;
        var monthDays = DateTime.DaysInMonth(year, month);
        var i = 0;
        var numberOfMonths = 6;
        var chosenDate = calculationInput.ChosenPayday;

        while (i < numberOfMonths)
        {
            var currentDate = new DateOnly(year, month, monthDays);
            if (currentDate.Day == chosenDate)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    fixedDate = currentDate;
                    fixedDatePayday.Add(fixedDate.ToString());
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
                else if (currentDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    fixedDate = currentDate.AddDays(-1);
                    fixedDatePayday.Add(fixedDate.ToString());
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
                else if (currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    fixedDate = currentDate.AddDays(-2);
                    fixedDatePayday.Add(fixedDate.ToString());
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
            }
            else
            {
                monthDays--;
            }
        }

        return fixedDatePayday;
    }
}