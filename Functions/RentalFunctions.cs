using System;
using Discord.Commands;
using Discord.WebSocket;
using Laced_Rentals_Bot.Functions.Database;

namespace Laced_Rentals_Bot.Functions
{
    public class RentalFunctions
    {
        public static int ParseTime(string timeText)
        {
            var minutes = 0;

            if (timeText.Contains("d"))
            {
                timeText = timeText.Replace("d", "");
                minutes = Convert.ToInt32(timeText) * 1440;
            }
            else if (timeText.Contains("h"))
            {
                timeText = timeText.Replace("h", "");
                minutes = Convert.ToInt32(timeText) * 60;
            }
            else if (timeText.Contains("m"))
            {
                timeText = timeText.Replace("h", "");
                minutes = Convert.ToInt32(timeText);
            }

            return minutes;
        }
    }
}