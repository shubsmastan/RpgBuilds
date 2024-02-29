namespace RpgBuilds.Server.Configurations;

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string BuildCollection { get; set; } = null!;
}