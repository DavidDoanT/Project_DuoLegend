using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuoLegend.Service
{
    public static class TimeProcess
    {
        public static string[] HowLongSince(DateTime timeDate)
        {
            string[] result = new string[2];
            if(DateTime.Now < timeDate)
            {
                throw new ArgumentException("big time must be bigger than small time");
            }
            TimeSpan temp = DateTime.Now.Subtract(timeDate);
            if(temp.TotalSeconds < 60)
            {
                result[0] = "";
                result[1] = "just now";
                return result;
            }
            if(temp.TotalMinutes < 60)
            {
                result[0] = temp.Minutes.ToString();
                result[1] = "m";
                return result;
            }
            if (temp.TotalHours < 24)
            {
                result[0] = temp.Hours.ToString();
                result[1] = "h";
                return result;
            }
            if (temp.TotalDays < 7)
            {
                result[0] = temp.Days.ToString();
                result[1] = "d";
                return result;
            }
            return result;



        }
    }
}
