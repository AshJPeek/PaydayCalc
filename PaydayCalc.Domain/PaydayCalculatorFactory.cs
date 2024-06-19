using PaydayCalc.Domain.Models;
using PaydayCalc.Domain.Ports;

namespace PaydayCalc.Domain;

public class PaydayCalculatorFactory
{
    public IPaydayCalculator Create(PaydayCalculatorType paydayCalculatorType)
    {
        return paydayCalculatorType switch
        {
            PaydayCalculatorType.FixedDate => new FixedDatePaydayCalculator(),
            PaydayCalculatorType.FourWeeks => new FourWeeksPaydayCalculator(),
            PaydayCalculatorType.LastBusinessDay => new LastBusinessDayPaydayCalculator(),
            PaydayCalculatorType.LastFriday => new LastFridayPaydayCalculator(),
            _ => throw new ArgumentOutOfRangeException(nameof(paydayCalculatorType), paydayCalculatorType, null)
        };
    }
}