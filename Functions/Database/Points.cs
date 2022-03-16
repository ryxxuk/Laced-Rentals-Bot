﻿using System;
using MySql.Data.MySqlClient;

namespace Laced_Rentals_Bot.Functions
{
    internal class Points
    {
        // Points database functions
        public static int GetPoints(ulong discordId)
        {
            var config = DiscordFunctions.GetConfig();
            var connectionStr = config["db_connection"].ToString();
            var result = 0;

            using var conn = new MySqlConnection(connectionStr);
            try
            {
                conn.Open();

                var checkCmd =
                    new MySqlCommand("SELECT points FROM points WHERE customer_id=@customerId",
                        conn);
                checkCmd.Parameters.AddWithValue("@customerId", discordId);
                checkCmd.Prepare();

                using var reader = checkCmd.ExecuteReader();

                if (!reader.HasRows) return result;

                while (reader.Read()) result = Convert.ToInt32(reader["points"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public static int AddPoints(ulong discordId, int points)
        {
            var config = DiscordFunctions.GetConfig();
            var connectionStr = config["db_connection"].ToString();

            using var conn = new MySqlConnection(connectionStr);
            try
            {
                conn.Open();

                var checkCmd =
                    new MySqlCommand("SELECT * FROM points WHERE customer_id=@customerId",
                        conn);
                checkCmd.Parameters.AddWithValue("@customerId", discordId);
                checkCmd.Prepare();

                using var reader = checkCmd.ExecuteReader();

                var hasRows = reader.HasRows;

                reader.Close();

                var updateCmd = hasRows
                    ? new MySqlCommand("UPDATE points SET points = @newPoints WHERE customer_id=@customerId",
                        conn)
                    : new MySqlCommand("INSERT INTO points (customer_id, points) VALUES (@customerId, @newPoints)",
                        conn);

                var newPoints = hasRows ? GetPoints(discordId) + points : points;

                updateCmd.Parameters.AddWithValue("@customerId", discordId);
                updateCmd.Parameters.AddWithValue("@newPoints", newPoints);
                updateCmd.Prepare();

                updateCmd.ExecuteNonQuery();

                return newPoints;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        public static int RemovePoints(ulong discordId, int points)
        {
            var config = DiscordFunctions.GetConfig();
            var connectionStr = config["db_connection"].ToString();

            var currentPoints = GetPoints(discordId);

            var resultPoints = currentPoints - points;

            if (resultPoints < 0) resultPoints = 0;

            using var conn = new MySqlConnection(connectionStr);
            try
            {
                conn.Open();

                var checkCmd =
                    new MySqlCommand("SELECT * FROM points WHERE customer_id=@customerId",
                        conn);
                checkCmd.Parameters.AddWithValue("@customerId", discordId);
                checkCmd.Prepare();

                using var reader = checkCmd.ExecuteReader();

                var hasRows = reader.HasRows;

                reader.Close();

                if (!hasRows) return 0;

                var updateCmd =
                    new MySqlCommand("UPDATE points SET points = @newPoints WHERE customer_id=@customerId",
                        conn);

                updateCmd.Parameters.AddWithValue("@customerId", discordId);
                updateCmd.Parameters.AddWithValue("@newPoints", resultPoints);
                updateCmd.Prepare();

                updateCmd.ExecuteNonQuery();

                return GetPoints(discordId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }
    }
}