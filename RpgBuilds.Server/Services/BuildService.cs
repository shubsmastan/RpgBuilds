using RpgBuilds.Server.Configurations;
using RpgBuilds.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RpgBuilds.BuildService;

public class BuildService
{
  private readonly IMongoCollection<Build> Build;

  public BuildService(IOptions<DbConnection> dbSettings)
  {
    var MongoClient = new MongoClient(dbSettings.Value.ConnectionString);
    var db = MongoClient.GetDatabase(dbSettings.Value.DatabaseName);
    Build = db.GetCollection<Build>(dbSettings.Value.BuildCollection);
  }

  public async Task<List<Build>> GetBuilds() => await Build.Find(_ => true).ToListAsync();

  public async Task<Build> GetBuild(string id) => 
    await Build.Find(b => b.Id == id).FirstOrDefaultAsync();

  public async Task CreateBuild(Build build) => await Build.InsertOneAsync(build);

  public async Task UpdateBuild(Build build) => await Build.ReplaceOneAsync(b => b.Id == build.Id, build);

  public async Task DeleteBuild(string id) => await Build.DeleteOneAsync(b => b.Id == id);
}