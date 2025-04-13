public static class DbConnectionHelper
{
    public static string MakeConnection(ILogger logger)
    {

        var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "";
        var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "";
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "";
        var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "";

        var connectionString = $"Server={dbHost};Database={dbName};User Id={dbUser};Password={dbPassword};TrustServerCertificate=True;";

        logger.LogInformation($"Connection host: {dbHost}, dataBase: {dbName}");

        return connectionString;
    }
}
