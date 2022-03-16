using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Laced_Rentals_Bot.Functions;
using Laced_Rentals_Bot.Functions.Database;

namespace Laced_Rentals_Bot.Modules
{
    public class Utility : ModuleBase<SocketCommandContext>
    {
       [Command("help")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task Help()
        {
            var embedBuilder = new EmbedBuilder();

            var embed = embedBuilder
                .WithAuthor(author =>
                {
                    author.IconUrl = "https://i.imgur.com/hKV9Pvv.png";
                    author.Name = "Laced Rentals";
                })
                .WithFooter("Laced Rentals")
                .WithThumbnailUrl("")
                .WithColor(Color.Blue)
                .WithTitle("Laced Rentals Bot Command Help")
                .WithFields(new EmbedFieldBuilder
                {
                    Name = "Commands",
                    Value =
                        "**~rental** {@botrole} {price in USD} {start date} {Length in days} {@customer} {@renter} {drop}\n*Records a new rental. Commission is paid to user who executes the command*\n" +
                        "**~points add** {@user} {points}\n*Adds points to a user*\n" +
                        "**~points remove** {@user} {points}\n*Removes points to a user*\n" +
                        "**~points check** {@user}\n*Checks points to a user*\n" +
                        "**~check**\n *Checks if the invoice has been paid.*\n" +
                        "**~paid** {rentalId}\n*Marks a manual rental as paid and sends a commission embed*\n" +
                        "**~cancel** {rentalId}\n*Cancels a rental and voids the invoice*\n" +
                        "**~addstripe** {@user} {staff/renter} {stripe id}\n*Adds a user to the stripe database*\n" +
                        "**~commission** {@user} {USD amount} {notes (optional)}\n *Creates a commissions invoice. Notes default to \"commissions\" *\n"
                })
                .WithCurrentTimestamp()
                .Build();

            await ReplyAsync("", false, embed);
        }
    }
}