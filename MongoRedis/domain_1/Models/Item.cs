using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace domain_1.Models;

public class Item
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
