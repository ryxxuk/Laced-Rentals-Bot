using System;
using System.Globalization;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Laced_Rentals_Bot.Functions;
using Laced_Rentals_Bot.Functions.Database;

namespace Laced_Rentals_Bot.Modules
{
    public class Rentals : ModuleBase<SocketCommandContext>
    {
        [Command("new")]
        [Alias("rent")]
        [Summary("Logs a new rental")]
        //[RequireUserPermission(GuildPermission.KickMembers)]
        public async Task NewRental(SocketRole bot, double price, SocketGuildUser customer, string startDate, string startTime, string rentalLength)
        {
           try
           {
               var startDateTime = DateTime.Parse(startDate, new CultureInfo("en-US", false));

               startDateTime = startTime == "now" ? DateTime.Now : startDateTime.AddHours(Convert.ToInt32(startTime));
                
               DateTime endDate;
                
               try
               {
                   endDate = startDateTime.AddMinutes(RentalFunctions.ParseTime(rentalLength));
               }
               catch
               {
                   await ReplyAsync($"'{rentalLength}' is not a valid time period. Valid examples: 1d, 4h, 30m", false);
                   return;
               }

               var id = RentalsDB.RecordNewRental(customer, bot.Id, price, startDateTime, endDate, Context.Channel.Id);

               await ReplyAsync("", false,
                   CustomEmbedBuilder.BuildRentalEmbed(id, customer.Username,bot.Id, $"**Start:** {startDateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} PST\n**End:** {endDate.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} PST", price));
           }
           catch
           {
               await ReplyAsync($"Failed creating new rental.", false);
           }
        }

        
    }
}