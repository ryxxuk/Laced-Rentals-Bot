using System;
using MySql.Data.MySqlClient;

namespace Laced_Rentals_Bot.Functions
{
    internal class BotStock
    {
        //public static int AddBotStock(ulong botId, string botName, int stock)
        //{
        //    var config = DiscordFunctions.GetConfig();
        //    var connectionStr = config["db_connection"].ToString();

        //    var currentPoints = GetPoints(discordId);

        //    var resultPoints = currentPoints - points;

        //    if (resultPoints < 0) resultPoints = 0;

        //    using var conn = new MySqlConnection(connectionStr);
        //    try
        //    {
        //        conn.Open();

        //        var checkCmd =
        //            new MySqlCommand("SELECT * FROM points WHERE customer_id=@customerId",
        //                conn);
        //        checkCmd.Parameters.AddWithValue("@customerId", discordId);
        //        checkCmd.Prepare();

        //        using var reader = checkCmd.ExecuteReader();

        //        var hasRows = reader.HasRows;

        //        reader.Close();

        //        if (!hasRows) return 0;

        //        var updateCmd =
        //            new MySqlCommand("UPDATE points SET points = @newPoints WHERE customer_id=@customerId",
        //                conn);

        //        updateCmd.Parameters.AddWithValue("@customerId", discordId);
        //        updateCmd.Parameters.AddWithValue("@newPoints", resultPoints);
        //        updateCmd.Prepare();

        //        updateCmd.ExecuteNonQuery();

        //        return GetPoints(discordId);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return -1;
        //    }
        //}

        //public static int RemoveBotStock(ulong botId, int stock)
        //{
        //    var config = DiscordFunctions.GetConfig();
        //    var connectionStr = config["db_connection"].ToString();

        //    var currentPoints = GetPoints(discordId);

        //    var resultPoints = currentPoints - points;

        //    if (resultPoints < 0) resultPoints = 0;

        //    using var conn = new MySqlConnection(connectionStr);
        //    try
        //    {
        //        conn.Open();

        //        var checkCmd =
        //            new MySqlCommand("SELECT * FROM points WHERE customer_id=@customerId",
        //                conn);
        //        checkCmd.Parameters.AddWithValue("@customerId", discordId);
        //        checkCmd.Prepare();

        //        using var reader = checkCmd.ExecuteReader();

        //        var hasRows = reader.HasRows;

        //        reader.Close();

        //        if (!hasRows) return 0;

        //        var updateCmd =
        //            new MySqlCommand("UPDATE points SET points = @newPoints WHERE customer_id=@customerId",
        //                conn);

        //        updateCmd.Parameters.AddWithValue("@customerId", discordId);
        //        updateCmd.Parameters.AddWithValue("@newPoints", resultPoints);
        //        updateCmd.Prepare();

        //        updateCmd.ExecuteNonQuery();

        //        return GetPoints(discordId);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return -1;
        //    }
        //}
        //public static int CheckBotStock(ulong botId, DateTime startTime)
        //{
        //    var config = DiscordFunctions.GetConfig();
        //    var connectionStr = config["db_connection"].ToString();

        //    var currentPoints = GetPoints(discordId);

        //    var resultPoints = currentPoints - points;

        //    if (resultPoints < 0) resultPoints = 0;

        //    using var conn = new MySqlConnection(connectionStr);
        //    try
        //    {
        //        conn.Open();

        //        var checkCmd =
        //            new MySqlCommand("SELECT * FROM points WHERE customer_id=@customerId",
        //                conn);
        //        checkCmd.Parameters.AddWithValue("@customerId", discordId);
        //        checkCmd.Prepare();

        //        using var reader = checkCmd.ExecuteReader();

        //        var hasRows = reader.HasRows;

        //        reader.Close();

        //        if (!hasRows) return 0;

        //        var updateCmd =
        //            new MySqlCommand("UPDATE points SET points = @newPoints WHERE customer_id=@customerId",
        //                conn);

        //        updateCmd.Parameters.AddWithValue("@customerId", discordId);
        //        updateCmd.Parameters.AddWithValue("@newPoints", resultPoints);
        //        updateCmd.Prepare();

        //        updateCmd.ExecuteNonQuery();

        //        return GetPoints(discordId);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return -1;
        //    }
        //}
    }
}