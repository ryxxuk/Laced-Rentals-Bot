using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Laced_Rentals_Bot.Functions.Database;
using Laced_Rentals_Bot.Models;

namespace Laced_Rentals_Bot.Functions
{
    internal class Autorole
    {
        //private DiscordSocketClient _client;
        //private ulong guild;

        //public void InitiateAutoRole(DiscordSocketClient client)
        //{
        //    _client = client;
        //    var config = DiscordFunctions.GetConfig();
        //    guild = Convert.ToUInt64(config["guild"].ToString());

        //    var task = Task.Run(async () =>
        //    {
        //        await Task.Delay(TimeSpan.FromSeconds(10));

        //        while (true)
        //        {
        //            try
        //            {
        //                await CheckAllUserRoles();
        //            }
        //            catch
        //            {
        //                // ignored
        //            }

        //            await Task.Delay(TimeSpan.FromMinutes(30));
        //        }
        //    });
        //}

        //public static async Task<bool> AddUserToRoleAsync(ulong discordId, ulong roleId, DateTime endTime,
        //    SocketCommandContext context)
        //{
        //    try
        //    {
        //        AutoroleDB.AddAutoRoleEntry(discordId, roleId, DateTime.Now, endTime);

        //        await context.Guild.GetUser(discordId).AddRoleAsync(context.Guild.GetRole(roleId));

        //        var embed = CustomEmbedBuilder.BuildAddedRoleEmbed(roleId, discordId, endTime);

        //        await context.Channel.SendMessageAsync("", false, embed);

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public async Task CheckAllUserRoles()
        //{
        //    var rolesToBeRemoved = AutoroleDB.GetOverdueRoleRevokes();

        //    if (rolesToBeRemoved is null || rolesToBeRemoved.Count == 0) return;

        //    foreach (var role in rolesToBeRemoved) await RemoveUserFromRole(role);

        //    Console.WriteLine($"{DateTime.Now} [Msg] {rolesToBeRemoved.Count} roles revoked!");
        //}

        //public async Task RemoveUserFromRole(BotInfo roleToBeRemoved)
        //{
        //    try
        //    {
        //        var guilda = _client.GetGuild(guild);
        //        var user = guilda.GetUser(roleToBeRemoved.DiscordId);
        //        await user.RemoveRoleAsync(roleToBeRemoved.RoleId);

        //        var dmChannel = await _client.GetUser(roleToBeRemoved.DiscordId).GetOrCreateDMChannelAsync();

        //        await dmChannel.SendMessageAsync(
        //            $"The {_client.GetGuild(guild).GetRole(roleToBeRemoved.RoleId).Name} role has now been removed from you! Thank you for the rental, We hope you consider using Slick Rentals again!");

        //        AutoroleDB.UpdateAutoRoleStatus(roleToBeRemoved.Id, "revoked");
        //    }
        //    catch
        //    {
        //        Console.WriteLine("Failed removing role... Maybe bot isn't connected yet");
        //    }
        //}
    }
}