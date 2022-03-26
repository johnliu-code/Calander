using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.OverflowException;

namespace Calander
{
    class Program
    {
        static void Main(string[] args)
        {
            //Print a Calander for practive C#
            int year = 2022;
            int month = 1;
            int date = 1;

            year = ChooseYearForClander(year);

            //Print Calander
            WriteLine($"{year} Calander");
            for (int i = 1; i <= 12; i++)
            {
                WriteLine($"\n {DateTimeFormatInfo.CurrentInfo.GetMonthName(i),-10}  \n--------------------------");
                GetDaysNames();
                GetDatesNumbers(year, month, date);
                month++;
            }

            ReadLine();
        }

        //Let user choose year to print a Calander
        private static int ChooseYearForClander(int year)
        {
            WriteLine("Please entre a year value for print a Calander: ");

            try
            {
                year = Convert.ToInt32(ReadLine());
            }
            catch (FormatException)
            {
                WriteLine($"Please entre a int value for the year!");
                return ChooseYearForClander(year);
            }

            if (year < 1 || year >= 10000)
            {
                WriteLine("The number is too small or too big for the year please try again with number between 1 and 9999!");
                return ChooseYearForClander(year);
            } 

            return year;
        }

        //Method get day names
        private static void GetDaysNames()
        {
            string[] days = DateTimeFormatInfo.CurrentInfo.ShortestDayNames;

            foreach (string day in days)
            {
                Write($"{day,-4}");
            }
        }

        //Method get date numbers
        private static void GetDatesNumbers(int year, int month, int date)
        {
            int datesInmonth = DateTime.DaysInMonth(year, month);       //Get total days in a month
            int day;

             while (date <= datesInmonth)
             {
                DateTime dateOfMonth = new DateTime(year, month, date);  //Get date value of a month
                day = (int)dateOfMonth.DayOfWeek;                        //Get day number of a week
                string space = " ";
                int times = 1;
                
                for (int row = 1; row <= 5; row++)
                {
                    WriteLine();

                    for (int column = 1; column <= 7; column++)
                    {
                        if (column == 7)
                            times++;
                        if (date <= 7 && times <= 1)                        //Only loop the first line to add empty space instead of date
                        {
                            if (column <= day && day != 7)
                            {
                                Write($"{space,-4}");                    //Add space to the columns
                            }
                            else
                            {
                                Write($"{date,-4}");                     //Print date in first line
                                date++;
                            }
                        } else if (date <= datesInmonth)
                        {                                                                              
                             Write($"{date,-4}");                        //Print date in rest lines and ending when reach maximum date;
                            date++; 
                        }
                    }
                }

             }
            WriteLine("\n--------------------------\n");
        }
    }
}
