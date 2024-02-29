using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace RpgBuilds.Server.Models;

public class Build {
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]

  public string Id {get; set; } = string.Empty;

  [BsonElement("name")]
  public string Name {get; set; } = string.Empty;

  [BsonElement("characterName")]
  public string CharacterName {get; set; } = string.Empty;

  [BsonElement("characterClass")]
  public string CharacterClass {get; set; } = string.Empty;


}