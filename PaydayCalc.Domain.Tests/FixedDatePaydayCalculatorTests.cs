using PaydayCalc.Domain.Models;

namespace PaydayCalc.Domain.Tests;

[TestFixture]
public class FixedDatePaydayCalculatorTests
{
    [Test]
    public void Calculate()
    {
        var calculationInput = new CalculationInput
        {
            StartingDate = new DateTime(2024, 9, 19),
            ChosenPayday = 23
        };

        var fixedDatePaydayCalculator = new FixedDatePaydayCalculator();
        var result = fixedDatePaydayCalculator.Calculate(calculationInput);
        var expectedResult = new List<string>
        {
            "23/09/2024",
            "23/10/2024",
            "22/11/2024",
            "23/12/2024",
            "23/01/2025",
            "21/02/2025"
        };

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}