using System;
using System.Collections.Generic;
using Laced_Rentals_Bot.Models;
using MySql.Data.MySqlClient;
using SlickRentals_Discord_Bot.Models;

namespace Laced_Rentals_Bot.Functions.Database
{
    public class AutoroleDB
    {
        public static long AddAutoRoleEntry(ulong discordId, ulong roleId, DateTime startTime, DateTime endTime)
        {
            var config = DiscordFunctions.GetConfig();
            var connectionStr = config["db_connection"].ToString();

            using var conn = new MySqlConnection(connectionStr);
            try
            {
                conn.Open();

                var cmd = new MySqlCommand(
                    "INSERT INTO auto_role(discord_id, role_id, start_time, end_time) values (@discord_id, @role_id, @start_time, @end_time)",
                    conn);
                cmd.Parameters.AddWithValue("@discord_id", discordId);
                cmd.Parameters.AddWithValue("@role_id", roleId);
                cmd.Parameters.AddWithValue("@start_time", startTime);
                cmd.Parameters.AddWithValue("@end_time", endTime);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                return cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        public static string UpdateAutoRoleStatus(int id, string status)
        {
            var config = DiscordFunctions.GetConfig();
            var connectionStr = config["db_connection"].ToString();

            using var conn = new MySqlConnection(connectionStr);
            try
            {
                conn.Open();

                var checkCmd = new MySqlCommand("UPDATE auto_role SET status=@status WHERE id=@id", conn);
                checkCmd.Parameters.AddWithValue("@id", id);
                checkCmd.Parameters.AddWithValue("@status", status);
                checkCmd.Prepare();

                using var reader = checkCmd.ExecuteReader();

                if (!reader.HasRows) return null;

                while (reader.Read()) return reader["stripe_id"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
            }

            return null;
        }

        public static List<AutoRoleDetails> GetOverdueRoleRevokes()
        {
            var config = DiscordFunctions.GetConfig();
            var connectionStr = config["db_connection"].ToString();

            using var conn = new MySqlConnection(connectionStr);
            try
            {
                conn.Open();

                var checkCmd =
                    new MySqlCommand("SELECT * FROM auto_role WHERE end_time<@now AND status='granted'", conn);
                checkCmd.Parameters.AddWithValue("@now", DateTime.Now);
                checkCmd.Prepare();

                using var reader = checkCmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    conn.Close();
                    return null;
                }

                var result = new List<AutoRoleDetails>();

                while (reader.Read())
                    result.Add(new AutoRoleDetails
                    {
                        Id = (int)reader["id"],
                        Status = (string)reader["status"],
                        DiscordId = Convert.ToUInt64(reader["discord_id"].ToString()),
                        RoleId = Convert.ToUInt64(reader["role_id"].ToString()),
                        ChannelId = Convert.ToUInt64(reader["channel_id"].ToString()),
                        StartTime = Convert.ToDateTime(reader["start_time"].ToString()),
                        EndTime = Convert.ToDateTime(reader["end_time"].ToString())
                    });

                conn.Close();
                conn.Dispose();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
            }

            return null;
        }
    }
}