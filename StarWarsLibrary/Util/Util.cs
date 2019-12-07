using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StarWarsLibrary.Util
{
    
    public static class Util
    {
        
        public static DateTime ConvertConsumableToHours(string type, int number)
        {

            DateTime dateTime = DateTime.Now;
            if (type.Contains("year"))
            {
                dateTime = dateTime.AddYears(number);
            }
            else if (type.Contains("month"))
            {

                dateTime = dateTime.AddMonths(number);
            }
            else if (type.Contains("week"))
            {

                dateTime = dateTime.AddDays((number * 7));
            }
            else if (type.Contains("day"))
            {
                dateTime = dateTime.AddDays(number);
            }
            else if (type.Contains("hour"))
            {
                dateTime = dateTime.AddHours(number);
            }
            else
            {

               
            }

            return dateTime;
        

    }
    public static  int  GetIntFromString(string value)
        {
            
            Int32.TryParse(Regex.Match(value, @"\d+").Value, out int  number);

            return number;
        }
        public static string TimeFromMins(decimal min) {

            
            Int64 tot_mins = Convert.ToInt64(min);
            Int64 days = tot_mins / 1440;
            Int64 weeks = days / 7;
            Int64 years = weeks / 52;
            Int64 hour = (tot_mins % 1440) / 60;
            Int64 mins = tot_mins % 60;
            Int64 daysRem = days % 365;

            if (mins >= 60)
            {
                return string.Format("{0} mins", mins);
            }
            else if (mins >= 3600)
            {
                return string.Format("{0} hours {1}mins",hour, mins);
            }

            else if (mins >= 10080)
            {
                return string.Format("{0} days {1}mins", days, mins);
            }

            else if (mins > 525600)
            {
                return string.Format("{0} days {1}mins", days, mins);
            }

            else if (mins <= 525600)
            {
                return string.Format("{0} year {1} days {2}mins", years, daysRem, mins);
            }

            return string.Format("{0} days {1} hours  {2} mins", days, hour, mins);


        }
    }
}
