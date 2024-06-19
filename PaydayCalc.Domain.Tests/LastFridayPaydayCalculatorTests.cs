using PaydayCalc.Domain.Models;

namespace PaydayCalc.Domain.Tests;

[TestFixture]
public class LastFridayPaydayCalculatorTests
{
    [Test]
    public void Calculate()
    {
        var calculationInput = new CalculationInput
        {
            StartingDate = new DateTime(2024, 6, 19),
            ChosenPayday = null
        };

        var lastFridayPaydayCalculator = new LastFridayPaydayCalculator();
        var result = lastFridayPaydayCalculator.Calculate(calculationInput);
        var expectedResult = new List<string>
        {
            "28/06/2024",
            "26/07/2024"
        };

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}