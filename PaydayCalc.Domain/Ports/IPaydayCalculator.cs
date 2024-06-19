using PaydayCalc.Domain.Models;

namespace PaydayCalc.Domain.Ports;

public interface IPaydayCalculator
{
    List<string> Calculate(CalculationInput calculationInput);
}