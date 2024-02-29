using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace RpgBuilds.Models;

public class Build {
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]

  public string Id {get; set; } = String.Empty;

  [BsonElement("name")]
  public string Name {get; set; } = String.Empty;

  [BsonElement("characterName")]
  public string CharacterName {get; set; } = String.Empty;

  [BsonElement("characterClass")]
  public string CharacterClass {get; set; } = String.Empty;
}