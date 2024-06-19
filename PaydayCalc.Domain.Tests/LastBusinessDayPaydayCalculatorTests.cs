using PaydayCalc.Domain.Models;

namespace PaydayCalc.Domain.Tests;

[TestFixture]
public class LastBusinessDayPaydayCalculatorTests
{
    [Test]
    public void Calculate()
    {
        var calculationInput = new CalculationInput
        {
            StartingDate = new DateTime(2024, 6, 19),
            ChosenPayday = null
        };

        var lastBusinessDayPaydayCalculator = new LastBusinessDayPaydayCalculator();
        var result = lastBusinessDayPaydayCalculator.Calculate(calculationInput);
        var expectedResult = new List<string>
        {
            "28/06/2024",
            "31/07/2024"
        };
        
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}