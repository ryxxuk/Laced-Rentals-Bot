using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Laced_Rentals_Bot.Modules
{
    public class Reference : ModuleBase<SocketCommandContext>
    {
        [Command("rentalsuccess")]
        //[RequireUserPermission(GuildPermission.KickMembers)]
        public async Task AddPoints(SocketGuildUser user, int points = 1)
        {
            var newPoints = Functions.Points.AddPoints(user.Id, points);

            await user.ModifyAsync(prop => prop.Nickname = $"{user.Username} ({newPoints})");
        }

        [Command("removeref")]
        //[RequireUserPermission(GuildPermission.KickMembers)]
        public async Task RemovePoints(SocketGuildUser user, int points)
        {
            var newPoints = Functions.Points.RemovePoints(user.Id, points);

            if (newPoints != -1)
                await ReplyAsync($"Removed {points} points from {user.Username}. They now have {newPoints} points!");
            else await ReplyAsync($"Failed to remove points to {user.Username}!");

            await user.ModifyAsync(prop => prop.Nickname = $"{user.Username} ({newPoints})");
        }
    }
}