namespace PaydayCalc.Domain.Models;

public enum PaydayCalculatorType
{
    FixedDate = 1,
    FourWeeks = 2,
    LastBusinessDay = 3,
    LastFriday = 4
}