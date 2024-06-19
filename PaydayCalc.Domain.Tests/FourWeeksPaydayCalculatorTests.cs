using PaydayCalc.Domain.Models;

namespace PaydayCalc.Domain.Tests;

[TestFixture]
public class FourWeeksPaydayCalculatorTests
{
    [Test]
    public void Calculate()
    {
        var calculationInput = new CalculationInput
        {
            StartingDate = new DateTime(2024, 6, 19),
            ChosenPayday = null
        };

        var fourWeeksPaydayCalculator = new FourWeeksPaydayCalculator();
        var result = fourWeeksPaydayCalculator.Calculate(calculationInput);
        var expectedResult = new List<string>
        {
            "17/07/2024",
            "14/08/2024",
            "11/09/2024",
            "09/10/2024",
            "06/11/2024",
            "04/12/2024"
        };
        
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
}