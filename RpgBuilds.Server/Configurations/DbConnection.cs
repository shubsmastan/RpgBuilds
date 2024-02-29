namespace RpgBuilds.Server.Configurations;

public class DbConnection
{
  public string ConnectionString {get; set;} = string.Empty;

  public string DatabaseName { get; set; } = string.Empty;

  public string BuildCollection { get; set; } = string.Empty;
}