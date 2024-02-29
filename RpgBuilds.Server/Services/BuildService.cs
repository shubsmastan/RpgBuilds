using RpgBuilds.Server.Configurations;
using RpgBuilds.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RpgBuilds.Server.Services;

public class BuildService
{
    private readonly IMongoCollection<Build> builds;

    public BuildService(IOptions<DatabaseSettings> dbSettings)
    {
        var MongoClient = new MongoClient(dbSettings.Value.ConnectionString);
        var db = MongoClient.GetDatabase(dbSettings.Value.DatabaseName);
        builds = db.GetCollection<Build>(dbSettings.Value.BuildCollection);
    }

    public async Task<List<Build>> GetBuilds() => await builds.Find(_ => true).ToListAsync();

    public async Task<Build> GetBuild(string id) =>
      await builds.Find(b => b.Id == id).FirstOrDefaultAsync();

    public async Task CreateBuild(Build build) => await builds.InsertOneAsync(build);

    public async Task UpdateBuild(Build build) => await builds.ReplaceOneAsync(b => b.Id == build.Id, build);

    public async Task DeleteBuild(string id) => await builds.DeleteOneAsync(b => b.Id == id);
}