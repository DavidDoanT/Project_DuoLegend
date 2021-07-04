using System;

namespace DuoLegend.Service
{
    public class TimeFormatService
    {
        //chuyển milisecond thành thời gian trận đấu 
        public static string gameDuration(long time)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(time);
            string gameTime = string.Format("{0:D1}h:{1:D2}m:{2:D2}s",
                         t.Hours,
                         t.Minutes,
                         t.Seconds
                         );
            return gameTime;
        }
        //chuyen milisecond thành ngày create game
        public static string gameCreate (string time)
        {
            var date = (new DateTime(1970, 1, 1)).AddMilliseconds(double.Parse(time));
            return date.ToString("dd/MM/yyyy");
        }
    }
}