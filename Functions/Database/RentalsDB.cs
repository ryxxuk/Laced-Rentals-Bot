using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Discord.WebSocket;
using Laced_Rentals_Bot.Models;
using MySql.Data.MySqlClient;

namespace Laced_Rentals_Bot.Functions.Database
{
    public class RentalsDB
    {
        internal static long RecordNewRental(SocketGuildUser customer, ulong botId, double price, DateTime startDate, DateTime endDate, ulong channelId)
        {
            var config = DiscordFunctions.GetConfig();
            var connectionStr = config["db_connection"].ToString();

            using var conn = new MySqlConnection(connectionStr);
            try
            {
                conn.Open();

                var cmd = new MySqlCommand(
                    "INSERT INTO rental_history(customer_id, channel_id, bot_id, price, start_date, end_date) values (@customer_id, @channel_id, @bot_id, @price, @start_date, @end_date)",
                    conn);
                cmd.Parameters.AddWithValue("@customer_id", botId);
                cmd.Parameters.AddWithValue("@channel_id", customer.Id);
                cmd.Parameters.AddWithValue("@bot_id", botId);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@start_date", startDate);
                cmd.Parameters.AddWithValue("@end_date", endDate);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                return cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public static bool UpdateStatus(int id, string status)
        {
            var config = DiscordFunctions.GetConfig();
            var connectionStr = config["db_connection"].ToString();

            using var conn = new MySqlConnection(connectionStr);
            try
            {
                conn.Open();

                var checkCmd =
                    new MySqlCommand("UPDATE rental_history SET rental_status=@status WHERE rental_id=@rental_id",
                        conn);
                checkCmd.Parameters.AddWithValue("@rental_id", id);
                checkCmd.Parameters.AddWithValue("@status", status);
                checkCmd.Prepare();

                checkCmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}