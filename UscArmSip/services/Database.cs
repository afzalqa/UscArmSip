using Npgsql;

namespace UscArmSip
{
    public sealed class Database
    {
        public static bool CheckTestUserDbData(UserData user)
        {
            return bool.Parse(GetValueFromDatabase(_usc,
                $"SELECT EXISTS(SELECT * FROM usc.stp.stp_users WHERE" +
                $" login = '{user.Login}' AND" +
                $" passhash = '{user.PassHash}' AND" +
                $" surname = '{user.LastName}' AND" +
                $" name = '{user.FirstName}' AND" +
                $" middle_name = '{user.MiddleName}' AND" +
                $" operator_portal = true AND" +
                $" operator_lk = true AND" +
                $" operator_call_center = true AND" +
                $" operator_soc_net = true AND" +
                $" is_admin = true AND" +
                $" is_blocked = '{user.Blocked}' AND" +
                $" email = '{user.Email}' AND" +
                $" notify = {user.InMailList})").Result);
        }

        public static void RestoreTestUserDbData(UserData user)
        {
            ExecuteQuery(_usc, "UPDATE stp.stp_users SET" +
                  $" login = '{user.Login}'," +
                  $" passhash = '{user.PassHash}'," +
                  $" surname = '{user.LastName}'," +
                  $" name = '{user.FirstName}'," +
                  $" middle_name = '{user.MiddleName}'," +
                  $" operator_portal = true," +
                  $" operator_lk = true," +
                  $" operator_call_center = true," +
                  $" operator_soc_net = true," +
                  $" is_admin = true," +
                  $" is_blocked = '{user.Blocked}'," +
                  $" email = '{user.Email}'," +
                  $" notify = '{user.InMailList}' WHERE id = 55;");
        }

        private async static void ExecuteQuery(string dbCredentials, string query)
        {
            //Vpn.Connect();

            await using NpgsqlConnection connection = new(dbCredentials);
            await connection.OpenAsync();
            await using NpgsqlCommand command = new(query, connection);
            await using var reader = await command.ExecuteReaderAsync();
            await reader.CloseAsync();

            reader.Dispose();

            //Vpn.Disconnect();
        }

        private async static Task<string> GetValueFromDatabase(string dbCredentials, string query)
        {
            // Vpn.Connect();

            string value = default;

            await using NpgsqlConnection connection = new(dbCredentials);
            await connection.OpenAsync();
            await using NpgsqlCommand q = new(query, connection);
            await using var reader = await q.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                value = reader.GetValue(0).ToString();
            await reader.CloseAsync();

            reader.Dispose();

            // Vpn.Disconnect();

            return value;
        }

        private const string _usc =
            "Host=test-esk-dbo.nposapfir.ru:5433;" +
            "Username=postgres;" +
            "Password=postgrepass;" +
            "Database=usc";
/*
        private const string _usccardholders =
            "Host=test-esk-dbo.nposapfir.ru:5436;" +
            "Username=postgres;" +
            "Password=postgrepass;" +
            "Database=usccardholders";*/
    }
}