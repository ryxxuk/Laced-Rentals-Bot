using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace SlickRentals_Discord_Bot.Modules
{
    public class Utility : ModuleBase<SocketCommandContext>
    {
        //[Command("botstock add")]
        //[RequireUserPermission(GuildPermission.KickMembers)]
        //public async Task AddBotStock(SocketGuildUser user, int points = 1)
        //{
        //    var newPoints = Functions.Points.AddPoints(user.Id, points);

        //    await user.ModifyAsync(prop => prop.Nickname = $"{user.Nickname} ({newPoints})");
        //}

        //[Command("botstock remove")]
        //[RequireUserPermission(GuildPermission.KickMembers)]
        //public async Task RemoveBotStock(SocketGuildUser user, int points = 1)
        //{
        //    var newPoints = Functions.Points.AddPoints(user.Id, points);

        //    await user.ModifyAsync(prop => prop.Nickname = $"{user.Nickname} ({newPoints})");
        //}

        //[Command("botstock view")]
        //[RequireUserPermission(GuildPermission.KickMembers)]
        //public async Task AddPoints(SocketGuildUser user, int points = 1)
        //{
        //    var newPoints = Functions.Points.AddPoints(user.Id, points);

        //    await user.ModifyAsync(prop => prop.Nickname = $"{user.Nickname} ({newPoints})");
        //}
    }
}