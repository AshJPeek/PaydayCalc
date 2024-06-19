namespace PaydayCalc.Domain.Models;

public record CalculationInput
{
    public required DateTime StartingDate { get; init; }
    public int? ChosenPayday { get; init; }
}