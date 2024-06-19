using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaydayCalc
{
    public class PayDayCalculators
    {
        public class FixedDate
        {
            public static List<string> FixedDateCalc(int year, int month, int chosenDate)
            {
                DateOnly fixedDate = new DateOnly();
                List<string> fixedDatePayday = new List<string>();
                var monthDays = DateTime.DaysInMonth(year, month);
                var i = 0;
                var numberOfMonths = 6;
                chosenDate = 23;

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
                            fixedDatePayday.Add(fixedDate.ToString()); i++;
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
                            fixedDatePayday.Add(fixedDate.ToString()); i++;
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
        public class LastBusinessDay
        {
            public static List<string> LastBusinessDayCalc(int year, int month)
            {
                DateOnly finalBusinessDay = new DateOnly();
                List<string> finalBusinessPayday = new List<string>();                              
                var monthDays = DateTime.DaysInMonth(year, month);
                var i = 0;
                var numberOfMonths = 6;

                while (i < numberOfMonths)
                {
                    var currentDate = new DateOnly(year, month, monthDays);
                    if (currentDate.DayOfWeek < DayOfWeek.Saturday && currentDate.DayOfWeek > DayOfWeek.Sunday)
                    {
                        finalBusinessDay = currentDate;
                        finalBusinessPayday.Add(finalBusinessDay.ToString());
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
                return finalBusinessPayday;
            }
        }
        public class LastFriday
        {
            public static List<string> LastFridayCalc(int year, int month)
            {
                DateOnly finalFriday = new DateOnly();

                var monthDays = DateTime.DaysInMonth(year, month);
                int i = 0;
                int numberOfMonths = 6;
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
        public class FourWeeks
        {
            public static List<string> FourWeeksCalc(int year, int month, int day)
            {
                DateOnly currentDay = new DateOnly(year, month, day);
                DateOnly payDay = new DateOnly();
                List<string> yearlyPayday = new List<string>();
                int i = 0;
                int numberOfWeeks = 12;

                while (i != numberOfWeeks)
                {
                    currentDay = currentDay.AddDays(28);
                    i++;
                    payDay = currentDay;
                    yearlyPayday.Add(payDay.ToString());
                }

                return yearlyPayday;

            }
        }
    }
}
