using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Discord.WebSocket;
using Laced_Rentals_Bot.Models;
using MySql.Data.MySqlClient;

namespace Laced_Rentals_Bot.Functions.Database
{
    public class BotStockDB
    {
        internal static object AddBotStock(SocketGuildUser customer, int botId, DateTime startDate, DateTime endDate, ulong channelId)
        {
            var config = DiscordFunctions.GetConfig();
            var connectionStr = config["db_connection"].ToString();

            using var conn = new MySqlConnection(connectionStr);
            try
            {
                conn.Open();

                var cmd = new MySqlCommand(
                    "INSERT INTO rental_history(bot, customer_id, renter_id, channel_id, price, rental_period, start_date, rental_length) values (@bot, @customer_id, @renter_id, @channel_id, @price, @rental_period, @start_date, @rental_length)",
                    conn);
                cmd.Parameters.AddWithValue("@bot", botId);
                cmd.Parameters.AddWithValue("@customer_id", customer.Id);
                cmd.Parameters.AddWithValue("@end_date", endDate);
                cmd.Parameters.AddWithValue("@channel_id", channelId);
                cmd.Parameters.AddWithValue("@start_date", startDate);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                return cmd.LastInsertedId.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Failed logging new rental!";
            }
        }

        internal static object RemoveBotStock(SocketGuildUser customer, int botId, DateTime startDate, DateTime endDate, ulong channelId)
        {
            var config = DiscordFunctions.GetConfig();
            var connectionStr = config["db_connection"].ToString();

            using var conn = new MySqlConnection(connectionStr);
            try
            {
                conn.Open();

                var cmd = new MySqlCommand(
                    "INSERT INTO rental_history(bot, customer_id, renter_id, channel_id, price, rental_period, start_date, rental_length) values (@bot, @customer_id, @renter_id, @channel_id, @price, @rental_period, @start_date, @rental_length)",
                    conn);
                cmd.Parameters.AddWithValue("@bot", botId);
                cmd.Parameters.AddWithValue("@customer_id", customer.Id);
                cmd.Parameters.AddWithValue("@end_date", endDate);
                cmd.Parameters.AddWithValue("@channel_id", channelId);
                cmd.Parameters.AddWithValue("@start_date", startDate);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                return cmd.LastInsertedId.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Failed logging new rental!";
            }
        }

        internal static object GetBotStock(SocketGuildUser customer, int botId, DateTime startDate, DateTime endDate, ulong channelId)
        {
            var config = DiscordFunctions.GetConfig();
            var connectionStr = config["db_connection"].ToString();

            using var conn = new MySqlConnection(connectionStr);
            try
            {
                conn.Open();

                var cmd = new MySqlCommand(
                    "INSERT INTO rental_history(bot, customer_id, renter_id, channel_id, price, rental_period, start_date, rental_length) values (@bot, @customer_id, @renter_id, @channel_id, @price, @rental_period, @start_date, @rental_length)",
                    conn);
                cmd.Parameters.AddWithValue("@bot", botId);
                cmd.Parameters.AddWithValue("@customer_id", customer.Id);
                cmd.Parameters.AddWithValue("@end_date", endDate);
                cmd.Parameters.AddWithValue("@channel_id", channelId);
                cmd.Parameters.AddWithValue("@start_date", startDate);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                return cmd.LastInsertedId.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Failed logging new rental!";
            }
        }
    }
}