using System;
using Discord;

namespace Laced_Rentals_Bot.Functions
{
    public class CustomEmbedBuilder
    {
        public static Embed BuildRentalEmbed(long id, string customerName, ulong botId, string drop, double price)
        {
            var embedBuilder = new EmbedBuilder();
            var embed = embedBuilder
                .WithAuthor(author =>
                {author.IconUrl = "https://i.imgur.com/Uw1L0KN.png";
                    author.Name = "Laced Rentals";
                })
                .WithFooter("Laced Rentals")
                .WithThumbnailUrl("")
                .WithColor(Color.DarkGreen)
                .WithTitle($"New Rental #{id} Created Successfully")
                .WithFields(new EmbedFieldBuilder
                {
                    Name = "Customer",
                    Value = customerName,
                    IsInline = true
                })
                .WithFields(new EmbedFieldBuilder
                {
                    Name = "Bot",
                    Value = $"<@&{botId}>",
                    IsInline = true
                })
                .WithFields(new EmbedFieldBuilder
                {
                    Name = "Rental Period",
                    Value = drop,
                    IsInline = false
                })
                .WithFields(new EmbedFieldBuilder
                {
                    Name = "Price",
                    Value = $"${price}",
                    IsInline = false
                })
                .WithCurrentTimestamp()
                .Build();
            return embed;
        }
        
        public static Embed BuildAddedRoleEmbed(ulong roleId, ulong discordId, DateTime endTime)
        {
            var embedBuilder = new EmbedBuilder();
            var embed = embedBuilder
                .WithAuthor(author =>
                {
                    author.IconUrl =
                        "https://i.imgur.com/Uw1L0KN.png";
                    author.Name = "Laced Rentals";
                })
                .WithColor(Color.Green)
                .WithTitle($"Guide Access Given! Expires: {endTime}")
                .WithDescription($"Granted <@&{roleId}> role to <@{discordId}> ")
                .WithFooter("Laced Rentals Auto Role")
                .WithCurrentTimestamp()
                .Build();
            return embed;
        }
    }
}